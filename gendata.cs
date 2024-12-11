/*
This code generates random data points based on a given function and plots them using OxyPlot.
You can install the required packages using NuGet Package Manager:
dotnet add package MathNet.Numerics
dotnet add package OxyPlot.Core
dotnet add package OxyPlot.WindowsForms
*/

using System;                           // this namespace contains the Random class and the Math class
using System.Collections.Generic;       // this namespace contains the List class 
using MathNet.Numerics.Distributions;   // this namespace contains the Normal class
using OxyPlot;                          // this namespace contains the PlotModel class
using OxyPlot.Series;                   // this namespace contains the ScatterSeries class 

public class DataGenerator
{
    /*
    This class generates random data points based on a given function.
    - Generates a list of data points.
    - Uses a default function f if none is provided.
    - Uses MathNet.Numerics.Distributions.Normal.Sample to add random noise.
    */
    public static List<DataPoint> GenerateData((int, int) xRange, int n = 100, Func<double, double> f = null)
    {
        if (f == null)
        {
            f = x => Math.Pow(x, 1.5) + Normal.Sample(0, 100);
        }

        var dataPoints = new List<DataPoint>();
        var random = new Random();
        var (xMin, xMax) = xRange;

        for (int i = 0; i < n; i++)
        {
            double x = random.NextDouble() * (xMax - xMin) + xMin;
            double y = f(x);
            dataPoints.Add(new DataPoint(x, y));
        }

        return dataPoints;
    }

    /*
    This class plots the generated data points using OxyPlot.
    - Plots the generated data points using OxyPlot.
    - Creates a scatter plot and displays it in a Windows Forms application.
    */
    public static void PlotData(List<DataPoint> dataPoints)
    {
        var plotModel = new PlotModel { Title = "Generated Data" };
        var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

        foreach (var point in dataPoints)
        {
            scatterSeries.Points.Add(new ScatterPoint(point.X, point.Y));
        }

        plotModel.Series.Add(scatterSeries);

        var plotView = new OxyPlot.WindowsForms.PlotView
        {
            Model = plotModel,
            Dock = System.Windows.Forms.DockStyle.Fill
        };

        var form = new System.Windows.Forms.Form
        {
            Text = "Data Plot",
            Width = 800,
            Height = 600
        };

        form.Controls.Add(plotView);
        System.Windows.Forms.Application.Run(form);
    }

    public static void Main(string[] args)
    {
        var dataPoints = GenerateData((0, 100));
        PlotData(dataPoints);
    }
}