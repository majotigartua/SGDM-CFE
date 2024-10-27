using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class DeviceRepositoryTests
    {
        private readonly Context _context;
        private readonly DeviceRepository _deviceRepository;

        public DeviceRepositoryTests()
        {
            _context = new Context();
            _deviceRepository = new DeviceRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var device = new Device
            {
                InventoryNumber = "123456",
                SerialNumber = "654321",
                IsCriticalMission = false,
                Notes = "Test",
                WorkCenterId = 1
            };
            var result = _deviceRepository.Add(device);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var device = _context.Devices.First();
            var result = _deviceRepository.Delete(device);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var devices = _deviceRepository.GetAll();
            Assert.NotEmpty(devices);
        }

        [Fact]
        public void GetById()
        {
            int deviceId = 1;
            var device = _deviceRepository.GetById(deviceId);
            Assert.NotNull(device);
            Assert.Equal(device.Id, deviceId);
        }

        [Fact]
        public void GetByMobileDevice()
        {
            var mobileDevice = _context.MobileDevices.First();
            int mobileDeivceId = mobileDevice.Id;
            var device = _deviceRepository.GetByMobileDevice(mobileDevice);
            Assert.NotNull(device);
            Assert.Contains(device.MobileDevices, md => md.Id == mobileDeivceId);
        }

        [Fact]
        public void GetByOpticalReader()
        {
            var opticalReader = _context.OpticalReaders.First();
            int opticalReaderId = opticalReader.Id;
            var device = _deviceRepository.GetByOpticalReader(opticalReader);
            Assert.NotNull(device);
            Assert.Contains(device.OpticalReaders, or => or.Id == opticalReaderId);
        }

        [Fact]
        public void GetByState()
        {
            var state = _context.States.First();
            int stateId = state.Id;
            var device = _deviceRepository.GetByState(state);
            Assert.NotNull(device);
            Assert.Contains(device.States, s => s.Id == stateId);
        }

        [Fact]
        public void GetByWorkCenter()
        {
            var workCenter = _context.WorkCenters.First();
            int workCenterId = workCenter.Id;
            var device = _deviceRepository.GetByWorkCenter(workCenter);
            Assert.NotEmpty(device);
            Assert.All(device, d => Assert.Equal(d.WorkCenterId, workCenterId));
        }

        [Fact]
        public void Update()
        {
            var device = _context.Devices.First();
            device.InventoryNumber = "123456";
            device.SerialNumber = "123456";
            device.IsCriticalMission = false;
            device.Notes = "Test";
            device.WorkCenterId = 1;
            var result = _deviceRepository.Update(device);
            Assert.True(result);
        }
    }
}