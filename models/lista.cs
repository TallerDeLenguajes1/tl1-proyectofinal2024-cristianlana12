namespace claseLista
{
    public class lista
    {
        const int MIN = 5;
        const int MAX = 30;
        public static void cargarListaId(List<int> id){
            for (int i = MIN; i <= MAX; i++)
            {
                id.Add(i);
            }
        }
    }
}