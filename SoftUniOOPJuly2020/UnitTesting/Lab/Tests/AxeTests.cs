using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 2;
    private const int AxeDurability = 2;
    private const int DummyHealth = 20;
    private const int DummyXp = 20;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyXp);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        axe = new Axe(10, 10);
        dummy = new Dummy(20, 20);
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe loses durability after attack");
    }

    [Test]
    public void AttackingWithBrokenAxe()
    {

        axe.Attack(dummy);
        axe.Attack(dummy);


        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}