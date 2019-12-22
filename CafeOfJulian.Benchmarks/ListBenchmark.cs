using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace CafeOfJulian.Benchmarks
{

    public class Question
    {
        public Question(int x, int y)
        {
            
        }
    }

    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [RPlotExporter]
    public class ListBenchmark
    {
        Dictionary<int, int> questionDict = new Dictionary<int, int>()
        {
            {1,3},
            {2,6 },
            {3,7 },
            {4,8 },
            {5,3},
            {6,6 },
            {7,7 },
            {8,8 },            
            {9,6 },
            {10,7 },
            {11,8 },          
            {12,6 },
            {13,7 },
            {14,8 },           
            {15,6 },
            {16,7 },
            {17,8 },          
            {18,6 },
            {19,7 },
            {20,8 },            
        };

        [Benchmark]
        public IReadOnlyList<Question> LoadQuestionsLINQ()
        {
            return questionDict.Select(item => new Question(item.Key, item.Value)).ToList().AsReadOnly();
        }

        [Benchmark]
        public IReadOnlyList<Question> LoadQuestionsLINQWithoutReadonlyCall()
        {
            return questionDict.Select(item => new Question(item.Key, item.Value)).ToList();
        }

        [Benchmark]
        public IReadOnlyList<Question> LoadQuestions()
        {
            var list = new List<Question>();

            foreach (var keyValue in questionDict)
            {
                list.Add(new Question(keyValue.Key, keyValue.Value));
            }
            return list.AsReadOnly();
        }
    }
}
