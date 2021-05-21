namespace GenericsANDTypeParametrs
{
    internal interface IWriteDataRepository<in T> //more derived
    {
        void AddData(T data);
        void DeleteData(T data);
    }
}