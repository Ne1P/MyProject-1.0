using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindWeigth
{
    public partial class Form1 : Form
    {
        public List<string> StartVertex = new List<string>();
        public List<string> NeedVisit = new List<string>();
        public List<int[]> WeigthList = new List<int[]>();
        public List<string[]> PathList = new List<string[]>();

        List<string> EndStartPoint = new List<string>();
        List<string[]> EndPath = new List<string[]>();
        List<int[]> EndWeigth = new List<int[]>();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt16(textBox1.Text);
            if (number <= 0 || number >= 31)
            {
                MessageBox.Show("Введіть коректне значення!", "Увага помилка");
            }
            else
            {
                StartVertex.Add(textBox1.Text);
                textBox3.Text += textBox1.Text + Environment.NewLine;
            }

            textBox1.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt16(textBox2.Text);
            if (number <= 0 || number >= 31)
            {
                MessageBox.Show("Введіть коректне значення!", "Увага помилка");
            }
            else
            {
                NeedVisit.Add(textBox2.Text);
                textBox4.Text += textBox2.Text + Environment.NewLine;
            }

           
            textBox2.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var g = new Graph();
            
            // Data start
            ///<summary>
            ///Дадаю вершини графа
            ///</summary>
            //добавление вершин
            g.AddVertex("1");
            g.AddVertex("2");
            g.AddVertex("3");
            //g.AddVertex("4");
            g.AddVertex("5");
            g.AddVertex("6");
            g.AddVertex("7");
            // g.AddVertex("8");
            g.AddVertex("9");
            //g.AddVertex("10");
            g.AddVertex("11");
            //g.AddVertex("12");
            g.AddVertex("13");
            //g.AddVertex("14");
            g.AddVertex("15");
            g.AddVertex("16");
            g.AddVertex("17");
            g.AddVertex("18");
            //g.AddVertex("19");
            //g.AddVertex("20");
            g.AddVertex("21");
            //g.AddVertex("22");
            //g.AddVertex("23");
            g.AddVertex("24");
            g.AddVertex("25");
            g.AddVertex("26");
            g.AddVertex("27");
            //g.AddVertex("28");
            g.AddVertex("29");
            g.AddVertex("30");

            ///<summary>
            ///Дадаю ребра графа
            ///</summary>
            g.AddEdge("1", "2", 2);
            g.AddEdge("2", "1", 2);
            g.AddEdge("1", "7", 2);
            g.AddEdge("7", "1", 2);
            g.AddEdge("7", "13", 2);
            g.AddEdge("13", "7", 2);
            g.AddEdge("2", "3", 2);
            g.AddEdge("3", "2", 2);
            g.AddEdge("3", "9", 2);
            g.AddEdge("9", "3", 2);
            g.AddEdge("9", "15", 2);
            g.AddEdge("15", "9", 2);
            g.AddEdge("15", "21", 2);
            g.AddEdge("21", "15", 2);
            g.AddEdge("15", "16", 2);
            g.AddEdge("16", "15", 2);
            g.AddEdge("21", "27", 2);
            g.AddEdge("27", "21", 2);
            g.AddEdge("27", "26", 2);
            g.AddEdge("26", "27", 2);
            g.AddEdge("26", "25", 2);
            g.AddEdge("25", "26", 2);
            g.AddEdge("16", "17", 2);
            g.AddEdge("17", "16", 2);
            g.AddEdge("17", "18", 2);
            g.AddEdge("17", "11", 2);
            g.AddEdge("18", "17", 2);
            g.AddEdge("11", "17", 2);
            g.AddEdge("11", "5", 2);
            g.AddEdge("5", "11", 2);
            g.AddEdge("5", "6", 2);
            g.AddEdge("6", "5", 2);
            g.AddEdge("18", "24", 2);
            g.AddEdge("24", "18", 2);
            g.AddEdge("24", "30", 2);
            g.AddEdge("30", "24", 2);
            g.AddEdge("30", "29", 2);
            g.AddEdge("29", "30", 2);

            // Data end

            ///<summary>
            ///Перевірка на наяність задачі. яку потрібно вирішити
            ///</summary>
            if (StartVertex.Count == 0 && NeedVisit.Count == 0)
            {
                MessageBox.Show("List.Count == null", "Error");

            }
            else
            {
                var TempStartVertex = StartVertex;
                var TempNeedVisit = NeedVisit;
                

                foreach (var n in TempNeedVisit)
                {

                    foreach (var s in TempStartVertex)
                    {///<summary>
                     ///Перебір всіх цілей з пошуком найкоротшого маршруту
                     ///</summary>

                        var dijkstra = new Dijkstra(g);
                        var path = dijkstra.FindShortestPath(s, n);
                        var weigts = dijkstra.Weidth();
                        int[] Weigth = new int[30];
                        string[] Path = new string[30];
                        int a = Convert.ToInt32(n);

                        Path[a] = path;
                        Weigth[a] = weigts;
                        PathList.Add(Path);
                        WeigthList.Add(Weigth);
                    }

                }
                if (StartVertex.Count == 1)
                {
                    if (NeedVisit.Count == 1)
                    {
                        var point = StartVertex.First();
                        var path = PathList.First();
                        var weigth = WeigthList.First();
                        MessageBox.Show("Маршрут :  " + path[Convert.ToInt32(NeedVisit.First())] + ";   " + "Відстань :  " + weigth[Convert.ToInt32(NeedVisit.First())], "Старт:  " + point);

                        //EndStartPoint.Remove(EndStartPoint.First());
                        //EndPath.Remove(EndPath.First());
                        //EndWeigth.Remove(EndWeigth.First());
                    }
                }   ///<summary>Test </summary>
                else
                {
                    if (StartVertex.Count == NeedVisit.Count || StartVertex.Count > NeedVisit.Count)
                    {
                        GetBestStartVertex();

                        foreach (var n in NeedVisit)
                        {
                            if(EndStartPoint.Count != 0)
                            {
                                var point = EndStartPoint.First();
                           
                            
                            var path = EndPath.First();
                            var weigth = EndWeigth.First();
                            MessageBox.Show("Маршрут :  " + path[Convert.ToInt32(n)] + ";   " + "Відстань :  " + weigth[Convert.ToInt32(n)], "Старт:  " + point);
                            }
                            EndStartPoint.Remove(EndStartPoint.First());
                            EndPath.Remove(EndPath.First());
                            EndWeigth.Remove(EndWeigth.First());
                        }
                    }
                    if(StartVertex.Count < NeedVisit.Count)
                    {
                        MessageBox.Show("Need mind");

                        GetBestStartVertex();

                        foreach (var n in NeedVisit)
                        {
                            if (EndStartPoint.Count != 0)
                            {
                                var point = EndStartPoint.First();


                                var path = EndPath.First();
                                var weigth = EndWeigth.First();
                                MessageBox.Show("Маршрут :  " + path[Convert.ToInt32(n)] + ";   " + "Відстань :  " + weigth[Convert.ToInt32(n)], "Старт:  " + point);
                            }
                            EndStartPoint.Remove(EndStartPoint.First());
                            EndPath.Remove(EndPath.First());
                            EndWeigth.Remove(EndWeigth.First());
                        }
                    }
                   
                }
            }
        }

        public void GetBestStartVertex()
        {
            List<string> TempStartVer = StartVertex;
            List<string> TempNeedVisit = NeedVisit;
            List<string[]> TempPathList = PathList;
            List<int[]> TempWeigthList = WeigthList;
            List<string> StartPoint= new List<string>();
            List<string[]> Path= new List<string[]>();
            List<int[]> Weigth= new List<int[]>();

            foreach (var n in TempNeedVisit)
            {
                foreach (var s in TempStartVer)
                {
                    StartPoint.Add(s);
                    Path.Add(TempPathList.First());
                    TempPathList.Remove(TempPathList.First());
                    Weigth.Add(TempWeigthList.First());
                    TempWeigthList.Remove(TempWeigthList.First());
                }
                
                while (StartPoint.Count > 1)
                {
                    string firstP = StartPoint.First();
                    StartPoint.Remove(firstP);
                    string secondP = StartPoint.First();
                    StartPoint.Remove(secondP);

                    string[] t1Path = Path.First();
                    Path.Remove(t1Path);
                    string[] t2Path = Path.First();
                    Path.Remove(t2Path);

                    int[] fWeigth = Weigth.First();
                    Weigth.Remove(fWeigth);
                    int[] sWeigth = Weigth.First();
                    Weigth.Remove(sWeigth);

                    int weigthOne = fWeigth[Convert.ToInt32(n)];
                    int weigthTwo = sWeigth[Convert.ToInt32(n)];

                    if(weigthOne == weigthTwo)
                    {
                        MessageBox.Show("Маршрути рівні");
                        StartPoint.Add(firstP);
                        Path.Add(t1Path);
                        Weigth.Add(fWeigth);
                        break;
                    }
                    else
                    {
                        if (weigthOne < weigthTwo)
                        {
                            StartPoint.Add(firstP);
                            Path.Add(t1Path);
                            Weigth.Add(fWeigth);
                        }
                        else
                        {
                            StartPoint.Add(secondP);
                            Path.Add(t2Path);
                            Weigth.Add(sWeigth);
                        }
                    }
                    EndStartPoint.Add(StartPoint.First());
                    EndPath.Add(Path.First());
                    EndWeigth.Add(Weigth.First());
                    StartPoint.Clear();
                    Path.Clear();
                    Weigth.Clear();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();

            StartVertex.Clear();
            NeedVisit.Clear();
            WeigthList.Clear();
            PathList.Clear();

            EndStartPoint.Clear();
            EndPath.Clear();
            EndWeigth.Clear();

        }
        
    }
}
