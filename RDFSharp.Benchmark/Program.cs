using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Order;
using RDFSharp.Model;
using BenchmarkDotNet.Jobs;
using RDFSharp.Semantics.OWL;
using RDFSharp.Query;
using System.IO;
using System.Reflection;
using System;
using System.Resources;
using System.Data;

namespace Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Test
    {
        RDFGraph SmallGraph;
        RDFGraph MediumGraph;
        RDFGraph LargeGraph;

        RDFSelectQuery emptyQuery;
        RDFSelectQuery fullQuery;

        [GlobalSetup]
        public void Setup()
        {
            TestFiles.GenerateFilesAndPaths();

            SmallGraph = RDFGraph.FromFile(RDFModelEnums.RDFFormats.RdfXml, TestFiles.small);
            MediumGraph = RDFGraph.FromFile(RDFModelEnums.RDFFormats.RdfXml, TestFiles.medium);
            LargeGraph = RDFGraph.FromFile(RDFModelEnums.RDFFormats.RdfXml, TestFiles.large);

            RDFVariable Subject = new RDFVariable("subject");
            RDFVariable Predicate = new RDFVariable("predicate");
            RDFVariable Object = new RDFVariable("object");
            RDFResource dogOf = new RDFResource(RDFVocabulary.DC.BASE_URI + "dogOf");

            RDFPattern s_do_o = new RDFPattern(Subject, dogOf, Object);
            RDFPattern s_p_o = new RDFPattern(Subject, Predicate, Object);

            emptyQuery = new RDFSelectQuery().AddPatternGroup(new RDFPatternGroup("PG1")
                .AddPattern(s_do_o)
            );

            fullQuery = new RDFSelectQuery().AddPatternGroup(new RDFPatternGroup("PG1")
                .AddPattern(s_p_o)
            );
        }

        [Benchmark(Description = "small graph: empty query")]
        public void SmallEmpty()
        {
            var result = emptyQuery.ApplyToGraph(SmallGraph);
        }

        [Benchmark(Description = "small graph: full query")]
        public void SmallFull()
        {
            var result = fullQuery.ApplyToGraph(SmallGraph);
        }

        [Benchmark(Description = "medium graph: empty query")]
        public void MediumEmpty()
        {
            var result = emptyQuery.ApplyToGraph(MediumGraph);
        }

        [Benchmark(Description = "medium graph: full query")]
        public void MediumFull()
        {
            var result = fullQuery.ApplyToGraph(MediumGraph);
        }

        [Benchmark(Description = "large graph: empty query")]
        public void LargeEmpty()
        {
            var result = emptyQuery.ApplyToGraph(LargeGraph);
        }

        [Benchmark(Description = "large graph: full query")]
        public void LargeFull()
        {
            var result = fullQuery.ApplyToGraph(LargeGraph);
        }
    }

    public class TestFiles
    {
        public static string small
        {
            get
            {
                return System.IO.Path.Combine(path, SmallFileName);
            }
        }
        public static string medium
        {
            get
            {
                return System.IO.Path.Combine(path, MediumFileName);
            }
        }
        public static string large
        {
            get
            {
                return System.IO.Path.Combine(path, LargeFileName);
            }
        }

        private static string path;
        private readonly static string SmallFileName = "small.rdf";
        private readonly static string MediumFileName = "medium.rdf";
        private readonly static string LargeFileName = "large.rdf";

        public static void GenerateFilesAndPaths()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.GetFullPath(sCurrentDirectory);

            using (FileStream fs = File.Open(System.IO.Path.Combine(path, SmallFileName), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var info = RDFSharp.Benchmark.Properties.Resources.small;
                fs.Write(info, 0, info.Length);
            }

            using (FileStream fs = File.Open(System.IO.Path.Combine(path, MediumFileName), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var info = RDFSharp.Benchmark.Properties.Resources.medium;
                fs.Write(info, 0, info.Length);
            }

            using (FileStream fs = File.Open(System.IO.Path.Combine(path, LargeFileName), FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var info = RDFSharp.Benchmark.Properties.Resources.large;
                fs.Write(info, 0, info.Length);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }
}