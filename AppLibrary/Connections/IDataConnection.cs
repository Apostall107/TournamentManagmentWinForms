using AppLibrary.Models;


namespace AppLibrary.Connections
{
    public interface IDataConnection
    {

        PrizeModel CreatePrize(PrizeModel model);

    }
}
