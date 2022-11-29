using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JEAU1H_HFT_2021222.Logic.GameLogic;

namespace JEAU1H_HFT_2021222.Test
{
    [TestFixture]
    public class TesterClass
    {
        static GameLogic gm;
        static StudioLogic st;
        static MinRequirementsLogic mr;
        static Mock<IRepository<Game>> GameRepository;
        static Mock<IRepository<Studio>> StudioRepository;
        static Mock<IRepository<MinRequirements>> MinRequirementsRepository;
        [SetUp]
        public void Init()
        {
           GameRepository = new Mock<IRepository<Game>>();
            //Setups
            GameRepository.Setup(x => x.ReadAll()).Returns(new List<Game>() {
                new Game("FarCry1", 1, "2008", 1,1),
                new Game("FarCry2", 2, "2008", 1,2),
                new Game("FarCry3", 3, "2012", 1,3),
                new Game("Dying Light", 4, "2015",2,4),
            }.AsQueryable());
            GameRepository.Setup(x => x.Read(1)).Returns(new Game("FarCry1", 1, "2008", 1, 1));
            GameRepository.Setup(x => x.Read(2)).Returns(new Game("FarCry2", 2, "2008", 1, 2));
            GameRepository.Setup(x => x.Read(3)).Returns(new Game("FarCry3", 3, "2012", 1, 3));
            GameRepository.Setup(x => x.Read(4)).Returns(new Game("Dying Light", 4, "2015", 2, 4));

            StudioRepository = new Mock<IRepository<Studio>>();
            //Setups
            StudioRepository.Setup(x => x.ReadAll()).Returns(new List<Studio>() {
               new Studio("Ubisoft",1,"Yves Guillemot"),
                new Studio("Square Enix",2,"Yosuke Matsuda")
            }.AsQueryable());
            StudioRepository.Setup(x => x.Read(1)).Returns(new Studio("Ubisoft", 1, "Yves Guillemot"));
            StudioRepository.Setup(x => x.Read(2)).Returns(new Studio("Square Enix", 2, "Yosuke Matsuda"));
            MinRequirementsRepository = new Mock<IRepository<MinRequirements>>();
            //Setups
            MinRequirementsRepository.Setup(x => x.ReadAll()).Returns(new List<MinRequirements>() {
               new MinRequirements(1,"Intel Core i7-7820X Processor","GeForce RTX 2060"),
                new MinRequirements(2,"AMD Ryzen 7 5800H","GeForce GTX 1080"),
                new MinRequirements(3,"AMD Ryzen Threadripper 2950X","GeForce GTX 1070 Ti"),
                new MinRequirements(4,"Intel Core i7-10700F Processor","Radeon RX 6600"),
            }.AsQueryable());
            MinRequirementsRepository.Setup(x => x.Read(1)).Returns(new MinRequirements(1, "Intel Core i7-7820X Processor", "GeForce RTX 2060"));
            MinRequirementsRepository.Setup(x => x.Read(2)).Returns(new MinRequirements(2, "AMD Ryzen 7 5800H", "GeForce GTX 1080"));
            MinRequirementsRepository.Setup(x => x.Read(3)).Returns(new MinRequirements(3, "AMD Ryzen Threadripper 2950X", "GeForce GTX 1070 Ti"));
            MinRequirementsRepository.Setup(x => x.Read(4)).Returns(new MinRequirements(4, "Intel Core i7-10700F Processor", "Radeon RX 6600"));
            gm = new GameLogic(GameRepository.Object,StudioRepository.Object,MinRequirementsRepository.Object);
            st = new StudioLogic(StudioRepository.Object);
            mr = new MinRequirementsLogic(MinRequirementsRepository.Object);
           
        }
        #region CreateTests
        [Test]
        public void GameCreateTestWithValidData()
        {
            Game GoatSimulator = new Game("GoatSimulator", 5, "2014", 1, 1);
            gm.Create(GoatSimulator);
            GameRepository.Verify(x => x.Create(GoatSimulator), Times.Once);
        }
        [Test]
        public void GameCreateTestWithInValidData()
        {
            Game GoatSimulator = new Game("GoatSimulator", 30110, "2014", 301, 30210);
            
            Assert.That(() => gm.Create(GoatSimulator), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void StudioCreateTestWithValidData()
        {
            Studio Blizzard = new Studio("Blizzard", 3, "Mr X");
            st.Create(Blizzard);
            StudioRepository.Verify(x => x.Create(Blizzard), Times.Once);
        }
        [Test]
        public void StudioCreateTestWithInValidData()
        {
            Studio Blizzard = new Studio();

            Assert.That(() => st.Create(Blizzard), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void MinReqCreateTestWithValidData()
        {
            MinRequirements req = new MinRequirements(5,"SimpleCPU","SimpleGPU");
            mr.Create(req);
            MinRequirementsRepository.Verify(x => x.Create(req), Times.Once);
        }
        [Test]
        public void MinReqCreateTestWithInValidData()
        {
            MinRequirements req = new MinRequirements(5, "SimpleCPUButLongeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeer", "SimpleGPU");

            Assert.That(() => mr.Create(req), Throws.TypeOf<ArgumentException>());
        }
        #endregion
        #region Non-Crud Test
        [Test]
        public void GamesWithStudiosTest()
        {
            IEnumerable<string> current = gm.GamesWithStudios();
            IEnumerable<string> expected = new List<string>()
            {
                "FarCry1 : Ubisoft",
                "FarCry2 : Ubisoft",
                "FarCry3 : Ubisoft",
                "Dying Light : Square Enix"


 
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        [Test]
        public void GamesWithRequirementsTest()
        {
            IEnumerable<string> current = gm.GamesWithRequirements();
            IEnumerable<string> expected = new List<string>()
            {
                "FarCry1: Intel Core i7-7820X Processor,GeForce RTX 2060",
                "FarCry2: AMD Ryzen 7 5800H,GeForce GTX 1080",
                "FarCry3: AMD Ryzen Threadripper 2950X,GeForce GTX 1070 Ti",
                "Dying Light: Intel Core i7-10700F Processor,Radeon RX 6600"
                
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        [Test]
        public void GamesWithStudiosAndRequirementsTest()
        {
            IEnumerable<string> current = gm.GamesWithStudiosAndRequirements();
            IEnumerable<string> expected = new List<string>()
            {
                "FarCry1 : Ubisoft, Intel Core i7-7820X Processor,GeForce RTX 2060",
                "FarCry2 : Ubisoft, AMD Ryzen 7 5800H,GeForce GTX 1080",
                "FarCry3 : Ubisoft, AMD Ryzen Threadripper 2950X,GeForce GTX 1070 Ti",
                "Dying Light : Square Enix, Intel Core i7-10700F Processor,Radeon RX 6600"
               
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        [Test]
        public void GamesWithThisStudioTest()
        {
            IEnumerable<Game> current = gm.GamesWithThisStudio("Square Enix");
            IEnumerable<Game> expected = new List<Game>()
            {
                new Game("Dying Light", 4, "2015",2,4)
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        [Test]
        public void GamesWithThisCPUTest()
        {
            IEnumerable<Game> current = gm.GamesWithThisCPU("Intel Core i7-10700F Processor");
            IEnumerable<Game> expected = new List<Game>()
            {
                new Game("Dying Light", 4, "2015",2,4)
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        [Test]
        public void ReleaseYearSearchTest()
        {
            IEnumerable<Game> current = gm.ReleaseYearSearch("2008");
            IEnumerable<Game> expected = new List<Game>()
            {
                new Game("FarCry1", 1, "2008", 1,1),
                new Game("FarCry2", 2, "2008", 1, 2),
            };
            Assert.That(current, Is.EqualTo(expected));
        }
        #endregion
        #region ReadTest
        [Test]
        public void GameReadTest()
        {
           

            Assert.That(() => gm.Read(2020), Throws.TypeOf<ArgumentException>());
        }
        #endregion
    }
}
