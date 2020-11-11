using System.ComponentModel.DataAnnotations.Schema;

namespace Pretriage.Entitis.Model
{

    [Table("Config")]
    public class Config
    {
        public Config()
        {
        }

        public Config(string description, string productCode, string productName, int numberOfUnits,
            double unitValue, bool status, bool isDeleted)
        {
            //Id = id;
            Description = description;
            ProductCode = productCode;
            ProductName = productName;
            NumberOfUnits = numberOfUnits;
            UnitValue = unitValue;
            Status = status;
            IsDeleted = isDeleted;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }

        public string Description { get; private set; }

        public string ProductCode { get; private set; }

        public string ProductName { get; private set; }

        public int NumberOfUnits { get; private set; }

        public double UnitValue { get; private set; }

        public bool Status { get; private set; }

        public bool IsDeleted { get; private set; }



        public void SetStatus(bool status)
        {
            Status = status;
        }

        public void SetDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetProductCode(string productCode)
        {
            ProductCode = productCode;
        }
        public void SetProductName(string productName)
        {
            ProductName = productName;
        }

    }
}
