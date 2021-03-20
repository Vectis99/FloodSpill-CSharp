using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace FloodSpill.Benchmarks
{
	public class BenchmarkRunner
	{
		public static void Main(string[] args)
		{
			// Upgrade to .NET 5.0 gave the following warning:
			//'ConfigExtensions.With(IConfig, params IDiagnoser[])' is obsolete: 'This method will soon be removed, please start using .AddDiagnoser() instead.'
			//			var config = ManualConfig.Create(DefaultConfig.Instance)
			//	.With(MemoryDiagnoser.Default);
			// So instead using:
			var config = ManualConfig.Create(DefaultConfig.Instance).AddDiagnoser(MemoryDiagnoser.Default);

			//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ArrayClearBenchmark>(config);
			var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<FloodSpillBenchmarks>(config);
			//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<ArrayBenchmark>(config);
			//var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<QueuesBenchmarks>(config);
		}
	}
}