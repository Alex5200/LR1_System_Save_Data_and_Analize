using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing.Printing;
using System.Globalization;
using System.Security.Cryptography;
using Accord.MachineLearning;
using Accord.Math.Decompositions;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics;
using System.Windows.Controls;



namespace IoTRobotWorldUDPServer
{

    public partial class Form1 : Form
    {

        bool Automatization = false;

        const int CMaxVisibleLogLines = 10;

        string UDPReceiveBuffer = "";

        string remoteAddress; // хост для отправки данных
        int remotePort; // порт для отправки данных
        int localPort; // локальный порт для прослушивания входящих подключений
        int currentCommanNumber = 0;
        int lastCommanNumber = 0;
        public delegate void ShowUDPMessage(string message);
        List<string> dataList = new List<string>();
        public ShowUDPMessage myDelegate;
        UdpClient udpClient; // = new UdpClient(11000);
        Thread thread2;
        int Frames;
        int FramesLenght;
        string[] dataForSave = { "az", "d1", "d2", "d3", "d4", "d5", "d6", "d7" };
        int d0, d1, d2, d3, d4, d5, d6, d7, le = 0;
        float x, y, re = 0;
        int az = 0;
        int globalTickCounter = 0;
        string Message;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("Угол", "Угол");
            this.dataGridView1.Columns.Add("Значение угла", "Значение угла");
            timer2.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создадим делегата метода распечатки сообщения от удаленного сервера
            myDelegate = new ShowUDPMessage(ShowUDPMessageMethod);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopUDPClient();
        }

        private void PrintLog(string s)
        {

            // CMaxVisibleLogLines
            ReportListBox.Items.Add(s);

            while (ReportListBox.Items.Count > CMaxVisibleLogLines)
            {
                ReportListBox.Items.RemoveAt(0);
            }
            ReportListBox.SelectedIndex = ReportListBox.Items.Count - 1;
            ReportListBox.SelectedIndex = -1;
        }
        private void PrintDataLidar(string s)
        {
            // CMaxVisibleLogLines
            DateTime dt = DateTime.Now;
            string time = dt.ToString("HH:mm:ss.fff");
            listBox1.Items.Add(dt + " > " + s);
            while (listBox1.Items.Count > CMaxVisibleLogLines)
            {
                listBox1.Items.RemoveAt(0);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        private void CheckStartStopUDPClient()
        {
            if (udpClient != null)
            {
                StartStopUDPClientButton.Text = "Stop";
                RemoteIPTextBox.Enabled = false;
                RemoteIPTextBox.BackColor = Color.LightGray;
                RemotePortTextBox.Enabled = false;
                RemotePortTextBox.BackColor = Color.LightGray;
                LocalIPTextBox.Enabled = false;
                LocalIPTextBox.BackColor = Color.LightGray;
                LocalPortTextBox.Enabled = false;
                LocalPortTextBox.BackColor = Color.LightGray;
            }
            else
            {
                StartStopUDPClientButton.Text = "Start";
                RemoteIPTextBox.Enabled = true;
                RemoteIPTextBox.BackColor = Color.White;
                RemotePortTextBox.Enabled = true;
                RemotePortTextBox.BackColor = Color.White;
                LocalIPTextBox.Enabled = true;
                LocalIPTextBox.BackColor = Color.White;
                LocalPortTextBox.Enabled = true;
                LocalPortTextBox.BackColor = Color.White;
            }
        }

        private void StopUDPClient()
        {
            if ((thread2 != null) && (udpClient != null))
            {
                thread2.Abort();
                udpClient.Close();
                thread2 = null;
                udpClient = null;
            }
            PrintLog("UDPClient stopped");
            CheckStartStopUDPClient();
        }

        private void StartUDPClient()
        {
            if (thread2 != null)
            {
                thread2.Abort();
            }
            if (udpClient != null)
            {
                udpClient.Close();
            }

            localPort = Int32.Parse(LocalPortTextBox.Text);
            try
            {
                udpClient = new UdpClient(localPort);
                thread2 = new Thread(new ThreadStart(ReceiveUDPMessage));
                //thread.IsBackground = true;
                thread2.Start();
                PrintLog("UDPClient started");
            }
            catch
            {
                PrintLog("UDPClient's start failed");
            }
            CheckStartStopUDPClient();
        }

        private void StartStopUDPClientButton_Click(object sender, EventArgs e)
        {
            if (udpClient == null)
            {
                StartUDPClient();
            }
            else
            {
                StopUDPClient();
            }
        }
        private string[] GetLidarData(string s)
        {
            // Здесь вы можете получить данные с лидара из какого-либо источника
            // Например, из файла или через сеть
            try
            {
                string[] dataOut = s.Split(' ');
                return dataOut;

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return null;
            }
        }
        int angleStep = 0;
        int cluster = 50;
        List<ClusterInfo> clusterInfos = null;
        public void CreateBitmap(string[] data)
        {
            // Инициализация компонентов
            int bitmapWidth = 600;
            int bitmapHeight = 399;
            Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Bitmap bitmap2 = new Bitmap(bitmapWidth, bitmapHeight);

            // Очистка DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            // Парсинг данных и вычисление максимального расстояния
            List<double> distances = new List<double>();
            foreach (string item in data)
            {
                if (int.TryParse(item, out int value) && value > 0)
                {
                    distances.Add(value / (double)numericUpDown1.Value);
                }
            }
            double maxDistance = distances.Any() ? distances.Max() : 1;

            // Масштабирование
            double scaleFactor = Math.Min(bitmapWidth / 2.0, bitmapHeight / 2.0) / maxDistance;
          
            // Сбор точек в полярных координатах с масштабированием
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < data.Length; i++)
            {
                if (!int.TryParse(data[i], out int value) || value <= 0) continue;

                double distance = (value / (double)numericUpDown1.Value) * scaleFactor;
                double angle = i * 360.0 / data.Length * Math.PI / 180.0;

                float x = (float)(bitmapWidth / 2 + distance * Math.Cos(angle));
                float y = (float)(bitmapHeight / 2 + distance * Math.Sin(angle));
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = $"Угол {angle}";
                row.Cells[1].Value = data[i]; // Пример значения угла
                dataGridView1.Rows.Add(row);
                points.Add(new PointF(x, y));
            }

            if (points.Count > 0)
            {
                var detectedWalls = new List<WallInfo>();

                int clusterCount = Math.Min((int)numericUpDownClusters.Value, points.Count);
                clusterCount = Math.Max(1, clusterCount);

                double[][] inputs = points.Select(p => new[] { (double)p.X, (double)p.Y }).ToArray();
                KMeans kmeans = new KMeans(clusterCount);
                KMeansClusterCollection clusters = kmeans.Learn(inputs);
                int[] labels = clusters.Decide(inputs);
                clusters.Score(inputs);
                // Сбор информации о кластерах
                clusterInfos = new List<ClusterInfo>();
                var rand = new Random();

                for (int i = 0; i < clusterCount; i++)
                {
                    var info = new ClusterInfo
                    {
                        ClusterColor = Color.FromArgb(rand.Next(150, 255), rand.Next(150, 255), rand.Next(150, 255)),
                        Indices = labels.Select((val, idx) => new { val, idx })
                                      .Where(x => x.val == i)
                                      .Select(x => x.idx)
                                      .ToList()
                    };

                    if (!info.Indices.Any()) continue;

                    var clusterPoints = inputs.Get(info.Indices);

                    // Анализ формы кластера ДО вычисления центроида
                    var tempCov = clusterPoints.Covariance();
                    double[,] covariance = new double[2, 2];
                    for (int x = 0; x < 2; x++)
                        for (int y = 0; y < 2; y++)
                            covariance[x, y] = tempCov[x][y];

                    var svd = new SingularValueDecomposition(covariance);
                    info.IsLinear = svd.Diagonal[0] > svd.Diagonal[1] * 3;

                    // Если кластер линейный (возможная стена), вычисляем центроид по-другому
                    if (info.IsLinear && clusterPoints.Length > 10)
                    {
                        // Находим линию стены через метод наименьших квадратов
                        double[] xValues = clusterPoints.GetColumn(0);
                        double[] yValues = clusterPoints.GetColumn(1);

                        // Линейная регрессия y = a*x + b
                        double xMean = xValues.Mean();
                        double yMean = yValues.Mean();

                        double covarianceXY = 0.0;
                        double varianceX = 0.0;

                        for (int j = 0; j < xValues.Length; j++)
                        {
                            covarianceXY += (xValues[j] - xMean) * (yValues[j] - yMean);
                            varianceX += Math.Pow(xValues[j] - xMean, 2);
                        }

                        double a = covarianceXY / varianceX; // Наклон
                        double b = yMean - a * xMean;       // Пересечение

                        // Находим проекцию среднего на линию стены
                        // Это будет наш новый "центроид" на стене
                        double centroidX = xMean;
                        double centroidY = a * centroidX + b;

                        info.Centroid = new[] { centroidX, centroidY };

                        // Сохраняем параметры стены для визуализации
                        double[] direction = svd.RightSingularVectors.GetColumn(0);
                        double[] projections = clusterPoints.Dot(direction);
                        int minIndex = projections.ArgMin();
                        int maxIndex = projections.ArgMax();

                        PointF startPoint = points[info.Indices[minIndex]];
                        PointF endPoint = points[info.Indices[maxIndex]];

                        detectedWalls.Add(new WallInfo
                        {
                            StartPoint = startPoint,
                            EndPoint = endPoint,
                            Length = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) +
                                    Math.Pow(endPoint.Y - startPoint.Y, 2)),
                            Angle = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X) * 180 / Math.PI,
                            Confidence = Math.Min(1.0, info.Indices.Count / 50.0)
                        });
                    }
                    else
                    {
                        // Для нелинейных кластеров используем обычный центроид
                        info.Centroid = clusterPoints.Mean(0);
                    }

                    info.CovarianceMatrix = covariance;
                    double[] stdDev = clusterPoints.StandardDeviation();
                    info.Density = clusterPoints.Length / (stdDev[0] + stdDev[1]);

                    clusterInfos.Add(info);
                    listBox3.Items.Clear();
                    listBox3.Items.Add("             ");

                    listBox3.Items.Add("IsLinear?: " + Convert.ToString(svd.Diagonal[0] > svd.Diagonal[1] * 3));
                    listBox3.Items.Add(clusterPoints.StandardDeviation().Mean());
                    listBox3.Items.Add("Вес кластера:");
                    listBox3.Items.Add(clusterPoints.Length / (stdDev[0] + stdDev[1]));
                    listBox3.Items.Add("Матрица ковариации:");
                    for (int x = 0; x < covariance.GetLength(0); x++)
                    {
                        string row = "";
                        for (int j = 0; j < covariance.GetLength(1); j++)
                        {
                            row += $"[{x},{j}]: {covariance[x, j]:F3}  ";
                        }
                        listBox3.Items.Add(row);
                    }
                    listBox3.Items.Add(""); // Пустая строка-разделитель                   
                    double[] centroid = clusterPoints.Mean(0);
                    listBox3.Items.Add($"Центроид кластера (N={clusterPoints.Length}):");
                    listBox3.Items.Add($"  X = {centroid[0]:F4}");
                    listBox3.Items.Add($"  Y = {centroid[1]:F4}");
                    // ... (остальная часть вывода информации в listBox3)
                }
                if (checkBox2.Checked)
                {
                    listBox4.Items.Clear();
                    foreach (var wall in detectedWalls.OrderByDescending(w => w.Length))
                    {
                        listBox4.Items.Add($"Стена: Длина={wall.Length:F1}см, Угол={wall.Angle:F1}°, Уверенность={wall.Confidence:P0}");
                        listBox4.Items.Add($"  От ({wall.StartPoint.X:F1}, {wall.StartPoint.Y:F1}) до ({wall.EndPoint.X:F1}, {wall.EndPoint.Y:F1})");
                        listBox4.Items.Add("");
                    }
                }

                // Отрисовка
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Отрисовка точек по кластерам
                    foreach (var cluster in clusterInfos)
                    {
                        var brush = new SolidBrush(cluster.ClusterColor);
                        foreach (int idx in cluster.Indices)
                        {
                            g.FillEllipse(brush, (float)inputs[idx][0] - 3, (float)inputs[idx][1] - 3, 6, 6);
                        }

                        // Отрисовка центроида - красный квадрат для стен, зелёный для не-стен
                        Brush centroidBrush = cluster.IsLinear && cluster.Indices.Count > 10 ? Brushes.Red : Brushes.Green;
                        g.FillRectangle(centroidBrush, (float)cluster.Centroid[0] - 3, (float)cluster.Centroid[1] - 3, 6, 6);
                    }

                    // Отрисовка стен
                    if (checkBox2.Checked)
                    {
                        foreach (var wall in detectedWalls)
                        {
                            Pen wallPen = new Pen(Color.FromArgb((int)(wall.Confidence * 255), Color.Red), 2);
                            g.DrawLine(wallPen, wall.StartPoint, wall.EndPoint);

                            // Подпись стены
                            PointF labelPos = new PointF(
                                (wall.StartPoint.X + wall.EndPoint.X) / 2,
                                (wall.StartPoint.Y + wall.EndPoint.Y) / 2);
                            g.DrawString($"L:{(int)wall.Length} A:{(int)wall.Angle}°",
                                         new Font("Arial", 8), Brushes.Black, labelPos);
                        }
                    }

                    // Робот в центре
                    g.FillEllipse(Brushes.Blue, bitmap.Width / 2 - 5, bitmap.Height / 2 - 5, 10, 10);
                }

                // ... (вывод информации о стенах в listBox4)
            }

            pictureBox1.Image = bitmap;
        }
        int ticks = 0;
        string oldText = null;
        public async void timer1_Tick(object sender, EventArgs e)
        {
            if (Message != null)
            {
                dataGridView1.DataSource = null;
                Message = Message.Trim('>');
                
                if (Message != null)
                {
                    if (Frames == dataList.Count-1)
                    {
                        NextFrame.Enabled = false;
                    }
                    else
                    {
                        NextFrame.Enabled= true;
                    }
                    bool write = true;
                   
                    string text = Message ;
                   
                    if (write)
                    {
                        ticks += 1;

                      
                        if (oldText != text)
                        {
                            dataList.Add(text);
                            oldText = text;
                        }
                        string[] data;

                        if (checkBox1.Checked)
                        {
                            data = GetLidarData(Message);
                            CreateBitmap(data);

                        }
                        else
                        {
                            try
                            {
                                if (dataList[Frames] != null )
                                {
                                    FrameName.Text = "Frame: " + Frames;
                                    data = GetLidarData(dataList[Frames]);
                                    if (clusterInfos == null)
                                    {
                                        CreateBitmap(data);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ERR");
                                }

                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("ERR: " + ex.ToString());

                                if (dataList[Frames] != null)
                                {
                                    data = GetLidarData(dataList[0]);
                                    FrameName.Text = "Frame: " + Frames;

                                    if (clusterInfos == null)
                                    {
                                        CreateBitmap(data);
                                    }
                                }
                            }
                            ticks = 0;
                        }
                    }
                }
            }


        }

        private void PrewFrame_Click(object sender, EventArgs e)
        {
            if (Frames >= 1)
            {
                clusterInfos = null;
                Frames -= 1;
            }
        }

        private void NextFrame_Click(object sender, EventArgs e)
        {
            if (Frames != dataList.Count)
            {
                clusterInfos = null;
                Frames++;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownClusters_ValueChanged(object sender, EventArgs e)
        {
            clusterInfos = null;
        }

        private void ClearFrame_Click(object sender, EventArgs e)
        {
           
            dataList = null;
            clusterInfos = null;
            Frames = 0;
            
        }


        private void ShowUDPMessageMethod(string message)
        {
            PrintLog("Remote >" + message);
            PrintDataLidar(message);
            // Получаем данные с лидара
            Message = message;



        }

        private void ReceiveUDPMessage()
        {
            string oldError = "";
            string oldMassage = null;
            while (true)
            {
                try
                {
                    string[] valuesToChek = textBox1.Text.Split(',');
                    IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0); // port);
                    byte[] content = udpClient.Receive(ref remoteIPEndPoint);
                    if (content.Length > 0)
                    {
                        string message = Encoding.ASCII.GetString(content);
                        string[] allMassage = message.Split(',');
                        string correctMassage = null;

                        for (int i = 0; i <= allMassage.Length; i++)
                        {
                            foreach (string values in valuesToChek)
                            {
                                if (allMassage[i].Contains("az"))
                                    az = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d0"))
                                    d0 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d1"))
                                    d1 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d2"))
                                    d2 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d3"))
                                    d3 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d4"))
                                    d4 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d5"))
                                    d5 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d6"))
                                    d6 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("d7"))
                                    d7 = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("x"))
                                    x = float.Parse(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }), CultureInfo.InvariantCulture.NumberFormat);
                                else if (allMassage[i].Contains("y"))
                                    y = float.Parse(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }), CultureInfo.InvariantCulture.NumberFormat);
                                else if (allMassage[i].Contains("le"))
                                    le = Convert.ToInt32(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));
                                else if (allMassage[i].Contains("t"))
                                    re = float.Parse(allMassage[i].Split(':')[1].Trim(new Char[] { '"' }));


                                if (allMassage[i].Contains('n'))
                                {
                                    var getData = allMassage[i].Split(':');
                                    var commandNumber = getData[1].Trim(new Char[] { '"' });
                                    lastCommanNumber = Int32.Parse(commandNumber);
                                    currentCommanNumber = lastCommanNumber;
                                }
                                if (allMassage[i].Contains(values))
                                {
                                    correctMassage += String.Join(" ", allMassage[i]);
                                    if (correctMassage.Length >= (textBox1.Text.Length * 1))
                                    {
                                        this.Invoke(myDelegate, new object[] { message + "\n" });
                                    }
                                }
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void SendUDPMessage(string s)
        {
            if (udpClient != null)
            {
                Int32 port = Int32.Parse(RemotePortTextBox.Text);
                IPAddress ip = IPAddress.Parse(RemoteIPTextBox.Text.Trim());
                IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
                byte[] content = Encoding.ASCII.GetBytes(s);
                try
                {
                    int count = udpClient.Send(content, content.Length, ipEndPoint);
                    if (count > 0)
                    {
                        PrintLog("Message has been sent.");
                    }
                }
                catch
                {
                    PrintLog("Error occurs.");
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            globalTickCounter += 1;
        }
        private void SendUDPMessageButton_Click(object sender, EventArgs e)
        {
            string s = UDPMessageTextBox.Text;
            if (AppendLFSymbolCheckBox.Checked) { s += "\n"; };
            SendUDPMessage(s);
        }

        private void RegularUDPSendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RegularUDPSendCheckBox.Checked)
            {
                UDPRegularSenderTimer.Enabled = true;
            }
            else
            {
                UDPRegularSenderTimer.Enabled = false;
            }
        }

        private void UDPRegularSenderTimer_Tick(object sender, EventArgs e)
        {
            SendUDPMessage(UDPMessageTextBox.Text);
        }

        private void RemotePortTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Automatization == false)
            {
                Automatization = true;
            }
            else
            {
                Automatization = false;
            }
        }
    }
}

public class ClusterInfo
{
    public List<int> Indices { get; set; } = new List<int>();
    public double[] Centroid { get; set; }
    public double Weight => Indices.Count;
    public double Density { get; set; }
    public double[,] CovarianceMatrix { get; set; }  // Изменили на double[,]
    public bool IsLinear { get; set; }
    public Color ClusterColor { get; set; }
}
public class WallInfo
{
    public PointF StartPoint { get; set; }
    public PointF EndPoint { get; set; }
    public double Length { get; set; }
    public double Angle { get; set; }
    public double Confidence { get; set; } // Уверенность, что это стена (0-1)
}