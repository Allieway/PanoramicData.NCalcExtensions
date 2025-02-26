﻿using System.Collections.Generic;
using System.Linq;

namespace PanoramicData.NCalcExtensions.Test;

public class CountTests
{
	private readonly List<string> _stringList = new List<string> { "a", "b", "c" };

	[Fact]
	public void Count_OfList_ReturnsExpectedResult()
	{
		var expression = new ExtendedExpression($"count(split('a piece of string', ' '))");
		var result = expression.Evaluate();
		result.Should().Be(4);
	}

	[Fact]
	public void Count_OfListOfString_ReturnsExpectedResult()
	{
		var expression = new ExtendedExpression($"count(x)");
		expression.Parameters.Add("x", _stringList);
		var result = expression.Evaluate();
		result.Should().Be(_stringList.Count);
	}

	[Fact]
	public void Count_OfEnumerableOfString_ReturnsExpectedResult()
	{
		var expression = new ExtendedExpression($"count(x)");
		expression.Parameters.Add("x", _stringList.AsEnumerable());
		var result = expression.Evaluate();
		result.Should().Be(_stringList.Count);
	}

	[Fact]
	public void Count_OfReadOnlyOfString_ReturnsExpectedResult()
	{
		var expression = new ExtendedExpression($"count(x)");
		expression.Parameters.Add("x", _stringList.AsReadOnly());
		var result = expression.Evaluate();
		result.Should().Be(_stringList.Count);
	}

	[Fact]
	public void Count_JArray_ReturnsExpectedResult()
	{
		var expression = new ExtendedExpression($"count(x)");
		expression.Parameters.Add("x", JArray.FromObject(_stringList));
		var result = expression.Evaluate();
		result.Should().Be(_stringList.Count);
	}
}
