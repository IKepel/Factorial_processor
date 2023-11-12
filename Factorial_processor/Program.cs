using Factorial_processor;

FactorialProcessor processor = new FactorialProcessor();

Console.WriteLine("Sequential mode:");
processor.Go(5, false);
processor.Go(10, false);
processor.Go(15, false);

Console.WriteLine("\nParallel mode:");
processor.Go(5, true);
processor.Go(10, true);
processor.Go(15, true);