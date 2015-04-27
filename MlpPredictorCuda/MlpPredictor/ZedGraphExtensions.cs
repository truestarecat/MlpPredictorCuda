using System;
using System.Drawing;
using ZedGraph;

namespace MlpPredictor
{
    public static class ZedGraphExtensions
    {
        public static void ClearGraph(this ZedGraphControl graph)
        {
            graph.GraphPane.CurveList.Clear();
            graph.Invalidate();
        }

        public static void SetGraphTitles(this ZedGraphControl graph, string xAxisTitle, string yAxisTitle, string graphTitle)
        {
            GraphPane pane = graph.GraphPane;

            pane.XAxis.Title.Text = xAxisTitle;
            pane.YAxis.Title.Text = yAxisTitle;
            pane.Title.Text = graphTitle;
        }

        public static void DrawGraph(this ZedGraphControl graph, string[] labels, string[] colors, float[][] data)
        {
            if (labels == null)
                throw new ArgumentNullException("labels");
            if (colors == null)
                throw new ArgumentNullException("colors");
            if (data == null)
                throw new ArgumentNullException("data");
            if (data[0] == null)
                throw new ArgumentNullException("data[0]");

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
