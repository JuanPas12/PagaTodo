namespace MinimalAPI.Services
{
    public class CalculatorService : ICalculatorService

    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="x">The first integer to add.</param>
        /// <param name="y">The second integer to add.</param>
        /// <returns>The sum of the two integers.</returns>
        public int add(int x, int y)
        {
            return x + y;
        }
    }
}
