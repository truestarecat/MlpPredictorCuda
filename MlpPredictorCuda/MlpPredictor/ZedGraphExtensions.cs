using System.Drawing;
using ZedGraph;

namespace MlpPredictor
{
    public static class ZedGraphExtensions
    {
        public static void ClearGraph(this ZedGraphControl graph)
        {
            SetGraphTitles(graph, "", "", "");
        }

        public static void SetGraphTitles(this ZedGraphControl graph, string xAxisTitle, string yAxisTitle, string graphTitle)
        {
            GraphPane pane = graph.GraphPane;

            pane.CurveList.Clear();
            pane.XAxis.Title.Text = "";
            pane.YAxis.Title.Text = "";
            pane.Title.Text = "";
        }

        public static void DrawGraph(this ZedGraphControl graph, string[] labels, string[] colors, float[][] data)
        {
            GraphPane pane = graph.GraphPane;

            pane.CurveList.Clear();

            PointPairList[] lists = new PointPairList[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                lists[i] = new PointPairList();
                for (int j = 0; j < data[i].Length; j++)
                {
                    lists[i].Add(j, data[i][j]);
                }
            }

            LineItem[] myCurves = new LineItem[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                myCurves[i] = pane.AddCurve(labels[i], lists[i], Color.FromName(colors[i]), SymbolType.None);
            }

            graph.AxisChange();
            graph.Invalidate();
        }
    }
}
