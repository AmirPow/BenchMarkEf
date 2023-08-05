// See https://aka.ms/new-console-template for more information
using benchmark;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<SingleVsWhereAndSingle>();
//var summary = BenchmarkRunner.Run<AnyVsExistBenchMark>();
//var summary = BenchmarkRunner.Run<AnyVsExistBenchMarkOnList>();

Console.WriteLine(summary);