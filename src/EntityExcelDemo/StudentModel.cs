namespace EntityExcelDemo
{
    public enum EGender
    {
        Undefined = 0,
        Male = 1,
        Female = 2
    }

    public class StudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EGender Gender { get; set; }

        public int Grade { get; set; }

        public double Score { get; set; }
    }
}