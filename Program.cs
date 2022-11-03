namespace TruckTour
{
    class Program
    {
        public static int truckTour(int[][] petrolpumps)
        {
            int n = petrolpumps.Length;
            int[] petrol = new int[n];
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)                             // we are storing the petrol and distance in two different arrays
            {
                petrol[i] = petrolpumps[i][0];
                distance[i] = petrolpumps[i][1];
            }
            int start = 0;
            int end = 1;
            int curr_petrol = petrol[start] - distance[start];      // we are storing the current petrol in a variable by subtracting the distance from the petrol
            while (start != end || curr_petrol < 0)                 // we check if the start and end are equal or the current petrol is less than 0
            {
                while (curr_petrol < 0 && start != end)             // if the current petrol is less than 0 and the start and end are not equal
                {
                    curr_petrol -= petrol[start] - distance[start]; // we subtract the petrol and distance from the current petrol
                    start = (start + 1) % n;                        // we increment the start by 1 and if it is equal to n we make it 0
                    if (start == 0)                                 // if the start is equal to 0
                        return -1;                                  // there is no solution so we return -1
                }
                curr_petrol += petrol[end] - distance[end];         // we add the petrol and distance to the current petrol
                end = (end + 1) % n;                                // we increment the end by 1
            }
            return start;                                           // we return the start
        }
        public static void Main(string[] args)
        {
                Console.WriteLine("Enter the number of petrol pumps");
                int n = Convert.ToInt32(Console.ReadLine());
                int[][] petrolpumps = new int[n][];
                Console.WriteLine("Enter the petrol and distance for each petrol pump");
                for (int petrolpumpsRowItr = 0; petrolpumpsRowItr < n; petrolpumpsRowItr++)
                {
                    petrolpumps[petrolpumpsRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp));
                }
                int result = Program.truckTour(petrolpumps);
                if (result == -1)
                    Console.WriteLine("No solution exists");
                else
                    Console.WriteLine("The truck can start from petrol pump " + result);
        }
    }
}