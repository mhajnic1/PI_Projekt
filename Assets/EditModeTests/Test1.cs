// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test1
{
    // A Test behaves as an ordinary method
    [Test]
public void TestMethod()
{
	int numberOne = 1;
	int numberTwo = 1;

	Assert.That(numberOne == numberTwo, "numbers are not equal");
}
}
