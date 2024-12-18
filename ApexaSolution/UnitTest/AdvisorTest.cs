using Apexa.DAL;
using Apexa.Data;
using Apexa.Data.Dto;
using Apexa.IDAL;
using Apexa.IService;
using Apexa.IService.Helper;
using Apexa.Service;
using Apexa.Service.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTest
{
    [NonParallelizable]
    public class AdvisorTests
    {
        private IAdvisorService _advisorService;
        private IAdvisorDal _advisorDal;
        private IValidator _validator;
        [SetUp]
        public void Setup()
        {
            IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
                services =>
                {
                    services.AddDbContext<AdvisorContext>();
                    services.AddSingleton<IUtil, Util>();
                    services.AddSingleton<IValidator, AdvisorValidator>();
                    services.AddSingleton<IAdvisorDal,AdvisorDal>();
                    services.AddSingleton<IAdvisorService, AdvisorService>();
                }).Build();
            _advisorService= _host.Services.GetRequiredService<IAdvisorService>();
            _advisorDal = _host.Services.GetRequiredService<IAdvisorDal>();
            _validator = _host.Services.GetRequiredService<IValidator>();
        }

        /// <summary>
        /// Creation test
        /// </summary>
        [Test]
        public void CreationTest()
        {
            Advisor advisor = CreateDefaultAdvisor();
            long id = _advisorDal.Add(advisor);
            Advisor? newAdvisor = _advisorDal.Get(id);
            Assert.IsNotNull(newAdvisor);

            Assert.That(newAdvisor.FullName, Is.EqualTo(advisor.FullName));
            Assert.That(newAdvisor.Address, Is.EqualTo(advisor.Address));
            Assert.That(newAdvisor.Sin, Is.EqualTo(advisor.Sin));
            Assert.That(newAdvisor.PhoneNumber, Is.EqualTo(advisor.PhoneNumber));
            Assert.That(newAdvisor.Status, Is.EqualTo(advisor.Status));
        }
        /// <summary>
        /// Update test
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Advisor advisor = CreateDefaultAdvisor();
            long id = _advisorDal.Add(advisor);
           
            advisor.FullName = "TestFullName2";
            _advisorDal.Update(id,advisor);
            Advisor? newAdvisor = _advisorDal.Get(id);
            Assert.IsNotNull(newAdvisor);

            Assert.That(newAdvisor.FullName, Is.EqualTo(advisor.FullName));
            
            

        }
        /// <summary>
        /// Delete test
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Advisor advisor = CreateDefaultAdvisor();
            long id = _advisorDal.Add(advisor);
            Console.WriteLine(id);
            _advisorDal.Delete(id);
            var a = _advisorDal.Get(id);
            if (a != null)
            {
                Console.WriteLine(a.Id);
            }

            Assert.IsNull(_advisorDal.Get(id));
        }

        /// <summary>
        /// MaskTest
        /// </summary>

        [Test]
        public void MaskTest()
        {
            var adivsor = CreateDefaultAdvisor();
            var apexaResult = _advisorService.GetAdvisor(_advisorDal.Add(adivsor));
            Assert.That((apexaResult.Result as Advisor).Sin, Is.EqualTo("******789"));

        }
        [Test]
        public void RequiredFieldTest()
        {
            var advisor = CreateDefaultAdvisor();
            advisor.FullName = null;
            var result = _advisorService.AddAdvisor(advisor);
            Assert.That( result.Errors.Count(), Is.EqualTo(1));
        }

        private Advisor CreateDefaultAdvisor()
        {
            Advisor advisor = new Advisor();
            advisor.FullName = "TestFullName";
            advisor.Address = "Test address";
            advisor.Sin = "123456789";
            advisor.PhoneNumber = "4169989969";
            advisor.Status = HealthStatus.Green;
            return advisor;
        }
    }
}