using System;
using NUnit.Framework;

[TestFixture]
public class ArbolBinarioBusquedaTests
{
    // Caso 1 - Insertar un valor en un árbol vacío
    [Test]
    public void Insertar_ArbolVacio_DevuelveTrue()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();

        // Act
        bool resultado = arbol.Insertar(50);

        // Assert
        Assert.That(resultado, Is.True);
        Assert.That(arbol.Cantidad, Is.EqualTo(1));
    }

    // Caso 2 - Insertar un valor repetido
    [Test]
    public void Insertar_ValorRepetido_DevuelveFalse()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);

        // Act
        bool resultado = arbol.Insertar(50);

        // Assert
        Assert.That(resultado, Is.False);
        Assert.That(arbol.Cantidad, Is.EqualTo(1));
    }

    // Caso 3 - Buscar un valor existente
    [Test]
    public void Contiene_ValorExistente_DevuelveTrue()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        bool resultado = arbol.Contiene(30);

        // Assert
        Assert.That(resultado, Is.True);
    }

    // Caso 4 - Buscar un valor inexistente
    [Test]
    public void Contiene_ValorInexistente_DevuelveFalse()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        bool resultado = arbol.Contiene(90);

        // Assert
        Assert.That(resultado, Is.False);
    }

    // Caso 5 - Eliminar un valor existente
    [Test]
    public void Eliminar_ValorExistente_DevuelveTrue()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        bool resultado = arbol.Eliminar(30);

        // Assert
        Assert.That(resultado, Is.True);
        Assert.That(arbol.Contiene(30), Is.False);
        Assert.That(arbol.Cantidad, Is.EqualTo(2));
    }

    // Caso 6 - Eliminar un valor inexistente
    [Test]
    public void Eliminar_ValorInexistente_DevuelveFalse()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        bool resultado = arbol.Eliminar(90);

        // Assert
        Assert.That(resultado, Is.False);
        Assert.That(arbol.Cantidad, Is.EqualTo(3));
    }

    // Caso 7 - Obtener el valor mínimo
    [Test]
    public void Minimo_ArbolConElementos_DevuelveMenorValor()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        int resultado = arbol.Minimo();

        // Assert
        Assert.That(resultado, Is.EqualTo(30));
    }

    // Caso 8 - Obtener el mínimo de un árbol vacío
    [Test]
    public void Minimo_ArbolVacio_LanzaExcepcion()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();

        // Act y Assert
        Assert.Throws<InvalidOperationException>(() => arbol.Minimo());
    }

    // Caso 9 - Comprobar la altura del árbol
    [Test]
    public void Altura_ArbolConDosNiveles_DevuelveDos()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        int resultado = arbol.Altura();

        // Assert
        Assert.That(resultado, Is.EqualTo(2));
    }

    // Caso 10 - Recorrer el árbol en orden
    [Test]
    public void EnOrden_ArbolConElementos_DevuelveListaOrdenada()
    {
        // Arrange
        var arbol = new ArbolBinarioBusqueda();
        arbol.Insertar(50);
        arbol.Insertar(30);
        arbol.Insertar(70);

        // Act
        var resultado = arbol.EnOrden();

        // Assert
        Assert.That(resultado, Is.EqualTo(new[] { 30, 50, 70 }));
    }
}