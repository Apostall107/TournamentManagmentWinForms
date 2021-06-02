using AppLibrary.Models;


namespace AppLibrary.Connections
{
    public interface IDataConnection
    {

        PrizeModel CreatePrize(PrizeModel model);
        PersonModel CreatePerson(PersonModel model);

        System.Collections.Generic.List<PersonModel> People_GetAll();

    }
}
