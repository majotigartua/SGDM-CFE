namespace SGDM_CFE.Entities.Models
{
    public class BusinessProcess
    {
        public int IdBusinessProcess { get; set; }
        public string? Name { get; set; }

        public BusinessProcess() { }

        public BusinessProcess(int idBusinessProcess, string? name)
        {
            IdBusinessProcess = idBusinessProcess;
            Name = name;
        }
    }
}