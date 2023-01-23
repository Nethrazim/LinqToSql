// See https://aka.ms/new-console-template for more information
using LinqToSql.Queries;

Q1GroupByDistinct q1 = new Q1GroupByDistinct();
q1.QToObjects();
q1.QToSql();

Q2Join q2 = new Q2Join();
q2.QToObjects();


Console.ReadKey();