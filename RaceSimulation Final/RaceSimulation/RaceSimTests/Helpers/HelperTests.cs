using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RaceSimulationWPF.Model;

namespace RaceSimulationWPF.Helpers.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void SerializeToXmlDocumentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortResultsAndAssignRanksTest()
        {
            
            ViewModel.RaceMainViewModel vm = new ViewModel.RaceMainViewModel();

            vm.RaceResults.Add(new RaceResult
            {
                Competitor =
                  (new Person { Id = 1, Name = "Third", Country = "US" }),
                Irm = null,
                Rank = null,
                NetTime = 100
            });

            vm.RaceResults.Add(new RaceResult
            {
                Competitor =
                (new Person { Id = 2, Name = "First", Country = "US" }),
                Irm = null,
                Rank = null,
                NetTime = 20
            });

            vm.RaceResults.Add(new RaceResult
            {
                Competitor =
                (new Person { Id = 3, Name = "Second", Country = "US" }),
                Irm = null,
                Rank = null,
                NetTime = 50
            });

            vm.RaceResults.Add(new RaceResult
            {
                Competitor =
             (new Person { Id = 4, Name = "forth", Country = "US" }),
                Irm = "DSQ",
                Rank = null,
                NetTime = null
            });


            IList<RaceResult> expectedResults = new List<RaceResult>() { };

       

            expectedResults.Add(new RaceResult
            {
                Competitor =
                (new Person { Id = 2, Name = "First", Country = "US" }),
                Irm = null,
                Rank = 1,
                NetTime = 20
            });

            expectedResults.Add(new RaceResult
            {
                Competitor =
                (new Person { Id = 3, Name = "Second", Country = "US" }),
                Irm = null,
                Rank = 2,
                NetTime = 50
            });


            expectedResults.Add(new RaceResult
            {
                Competitor =
                  (new Person { Id = 1, Name = "Third", Country = "US" }),
                Irm = null,
                Rank = 3,
                NetTime = 100
            });


            expectedResults.Add(new RaceResult
            {
                Competitor =
             (new Person { Id = 4, Name = "forth", Country = "US" }),
                Irm = "DSQ",
                Rank = 4,
                NetTime = null
            });

            vm.RaceResults = Helper.SortResultsAndAssignRanks(vm.RaceResults);

            Assert.AreEqual(vm.RaceResults[0].Rank, expectedResults[0].Rank);
            Assert.AreEqual(vm.RaceResults[1].Rank, expectedResults[1].Rank);
            Assert.AreEqual(vm.RaceResults[2].Rank, expectedResults[2].Rank);
            Assert.AreEqual(vm.RaceResults[3].Rank, expectedResults[3].Rank);
            Assert.AreEqual(vm.RaceResults[0].NetTime, expectedResults[0].NetTime);
            Assert.AreEqual(vm.RaceResults[1].NetTime, expectedResults[1].NetTime);
            Assert.AreEqual(vm.RaceResults[2].NetTime, expectedResults[2].NetTime);
            Assert.AreEqual(vm.RaceResults[3].NetTime, expectedResults[3].NetTime);
            Assert.AreEqual(vm.RaceResults[0].EventTime, expectedResults[0].EventTime);
            Assert.AreEqual(vm.RaceResults[1].EventTime, expectedResults[1].EventTime);
            Assert.AreEqual(vm.RaceResults[2].EventTime, expectedResults[2].EventTime);
            Assert.AreEqual(vm.RaceResults[3].EventTime, expectedResults[3].EventTime);            


        }
    }
}