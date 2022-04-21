
		List<NumberList> numbers = new List<NumberList>();
		numbers.Add(new NumberList(1, "One"));
		numbers.Add(new NumberList(2, "Two-Next"));
		numbers.Add(new NumberList(2, "Two"));
		numbers.Add(new NumberList(3, "Three"));
		numbers.Add(new NumberList(4, "Four"));
		numbers.Add(new NumberList(4, "Four-Next"));
		numbers.Add(new NumberList(5, "Five"));
		numbers.Add(new NumberList(6, "Six"));
		numbers.Add(new NumberList(6, "Six-Next"));
		numbers.Add(new NumberList(7, "Seven"));
		numbers.Add(new NumberList(8, "Eight"));
		numbers.Add(new NumberList(8, "Eight-Next"));
		numbers.Add(new NumberList(9, "Nine"));
		numbers.Add(new NumberList(10, "Ten"));

		// public static IOrderedEnumerable<TSource> 
		//		OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		IEnumerable<NumberList> results = numbers.OrderBy(n => n.name);
		Console.WriteLine("OrderBy:");
		foreach (NumberList number in results)
			Console.WriteLine(number.ToString());


		//public static IOrderedEnumerable<TSource>
		//	OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		IEnumerable<NumberList> results1 = numbers.OrderByDescending(n => n.name);
		Console.WriteLine("\n\nOrderByDescending:");
		foreach (NumberList number in results1)
			Console.WriteLine(number.ToString());

		//public static IOrderedEnumerable<TSource> 
		//	ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
		IEnumerable<NumberList> results2 = numbers.OrderBy(n => n.number).ThenByDescending(n => n.name);
		Console.WriteLine("\n\nOrderBy, ThenBy:");
		foreach (NumberList number in results2)
			Console.WriteLine(number.ToString());


public class NumberList
{
	public int number { get; set; }
	public string name { get; set; }
	public NumberList(int number, string name)
	{
		this.number = number;
		this.name = name;
	}
	public override string ToString()
	{
		return this.name;
	}
}