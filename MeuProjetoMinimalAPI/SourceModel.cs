namespace MeuProjetoMinimalAPI
{
    public class BonusStatement
    {
        public List<Result> results { get; set; }
    }

    public class D
    {
        public List<Result> results { get; set; }
    }

    public class Level
    {
        public Metadata __metadata { get; set; }
        public string Customer { get; set; }
        public string LevelDescription { get; set; }
        public string NextLevel { get; set; }
        public string PointsForNextlevel { get; set; }
    }

    public class Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Result
    {
        public Metadata __metadata { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public BonusStatement BonusStatement { get; set; }
        public Level Level { get; set; }
        public string Customer { get; set; }
        public string ExpirateBonus { get; set; }
        public object? ExpirateDate { get; set; }
        public string Value { get; set; }
        public string? Date { get; set; }
        public string ExpirateMessage { get; set; }
        public int Points { get; set; }
        public int PointsBalance { get; set; }
        public int PointsHistorical { get; set; }
        public string NotaFiscalNumber { get; set; }
        public string NotaFiscalSerie { get; set; }
        public string ContractNumber { get; set; }
        public string EntryCode { get; set; }
        public string EntryDescription { get; set; }
        public string EntryUserID { get; set; }
        public string BolOrderNumber { get; set; }
        public int CashPurchases { get; set; }
        public int FinancedPurchases { get; set; }
        public string PointsBalanceValue { get; set; }
    }

    public class Root
    {
        public D d { get; set; }
    }

}
