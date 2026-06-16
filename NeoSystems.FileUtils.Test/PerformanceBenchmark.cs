using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace NeoSystems.FileUtils.Test
{
    [TestFixture]
    public class PerformanceBenchmark
    {
        private string _testFolderPath = "";

        [OneTimeSetUp]
        public void Setup()
        {
            _testFolderPath = Path.Combine(Path.GetTempPath(), "BenchmarkFolder_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(_testFolderPath);

            // Create 10000 files
            for (int i = 0; i < 10000; i++)
            {
                File.WriteAllText(Path.Combine(_testFolderPath, $"file_{i}.txt"), "test");
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(_testFolderPath))
                Directory.Delete(_testFolderPath, true);
        }

        [Test]
        public void BenchmarkGetNewestFile()
        {
            // Warm up
            FolderUtilities.GetNewestFile(_testFolderPath);
            FolderUtilities.GetOldestFile(_testFolderPath);

            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++)
            {
                FolderUtilities.GetNewestFile(_testFolderPath);
            }
            sw1.Stop();

            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++)
            {
                FolderUtilities.GetOldestFile(_testFolderPath);
            }
            sw2.Stop();

            Console.WriteLine($"GetNewestFile took {sw1.ElapsedMilliseconds} ms for 10 iterations.");
            Console.WriteLine($"GetOldestFile took {sw2.ElapsedMilliseconds} ms for 10 iterations.");
        }
    }
}
