namespace Contract
{
    public struct ProfitDto
    {
       public int TimeInterval { get; set; }
       public double Profit {  get; set; }
    }
    public struct ProfitWeekDto
    {
       public string TimeInterval { get; set; }
       public double Profit {  get; set; }
    }
}
