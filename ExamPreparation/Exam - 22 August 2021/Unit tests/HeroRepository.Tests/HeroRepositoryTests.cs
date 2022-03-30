using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void EmptyConstructorWorks()
    {
        HeroRepository repository = new HeroRepository();
        
        Assert.AreEqual(0, repository.Heroes.Count);

    }

    [Test]
    public void CanCreateValidHeroes()
    {
        HeroRepository repository = new HeroRepository();

        repository.Create(new Hero("Ivan", 30));
        Assert.AreEqual(1, repository.Heroes.Count);

        repository.Create(new Hero("Gosho", 11));
        Assert.AreEqual(2, repository.Heroes.Count);

        repository.Create(new Hero("Pesho", 69));
        Assert.AreEqual(3, repository.Heroes.Count);
    }

    [Test]
    public void CantAddHeroThatIsNull()
    {
        var repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => repository.Create(null));
    }

    [Test]
    public void CantAddHeroThatAlreadyExists()
    {
        var repository = new HeroRepository();
        repository.Create(new Hero("Ivan", 30));
        repository.Create(new Hero("Gosho", 11));

        Assert.Throws<InvalidOperationException>(() => repository.Create(new Hero("Ivan", 29)));
    }

    [Test]
    public void CanRemoveHero()
    {
        var repository = new HeroRepository();
        var hero = new Hero("Ivan", 30);
        var hero2 = new Hero("Gosho", 11);
        repository.Create(hero);
        repository.Create(hero2);

        Assert.AreEqual(true, repository.Remove("Ivan"));
        Assert.AreEqual(1, repository.Heroes.Count);

        Assert.AreEqual(true, repository.Remove("Gosho"));
        Assert.AreEqual(0, repository.Heroes.Count);
    }

    [Test]
    [TestCase(null)]
    [TestCase(" ")]
    public void CantRemoveNullOrWhitespace(string name)
    {
        var repository = new HeroRepository();
        repository.Create(new Hero("Ivan", 30));

        Assert.Throws<ArgumentNullException>(() => repository.Remove(name));
    }

    [Test]
    public void GetHeroWithTheHighestLevel()
    {
        HeroRepository repository = new HeroRepository();

        var hero = new Hero("Ivan", 30);
        var highest = new Hero("Pesho", 69);
        var hero2 = new Hero("Gosho", 11);
        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(highest);


        Assert.AreEqual(highest, repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroWorks()
    {
        HeroRepository repository = new HeroRepository();

        var hero = new Hero("Ivan", 30);
        var hero2 = new Hero("Gosho", 11);
        var hero3 = new Hero("Pesho", 69);
        repository.Create(hero);
        repository.Create(hero2);
        repository.Create(hero3);

        Assert.AreEqual(hero2, repository.GetHero("Gosho"));
        Assert.AreEqual(hero, repository.GetHero("Ivan"));
        Assert.AreEqual(hero3, repository.GetHero("Pesho"));
    }
}