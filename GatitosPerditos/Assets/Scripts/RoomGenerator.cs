using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject []salas;

    private int[,] matriz;

	private int xMeio = 2;
	private int yMeio = 2;

	private int largura = 5;
	private int altura = 5;

	private Vector3 transformSala;



    void Start()
    {
        matriz = new int[altura, largura];

        for (int i = 0; i < altura; i++)
        {
            for (int j = 0; j < largura; j++)
            {
                matriz[i, j] = -1;
            }
        }

        RandTile(xMeio, yMeio);
    }

    private void RandTile(int linha, int coluna)
	{
		int numero;

		if (xMeio == linha && yMeio == coluna)
		{
			numero = Random.Range(41, 201);
		}
		else
		{
			numero = Random.Range(0, 201);
		}


		if (numero >= 0 && numero <= 40)
		{
			matriz[linha, coluna] = 0;

			InstanciaSala(linha, coluna, 0);
		}
		else if (numero > 40 && numero <= 72)
		{
			matriz[linha, coluna] = 1;

			InstanciaSala(linha, coluna, 1);
		}
		else if (numero > 72 && numero <= 104)
		{
			matriz[linha, coluna] = 2;

			InstanciaSala(linha, coluna, 2);
		}
		else if (numero > 104 && numero <= 136)
		{
			matriz[linha, coluna] = 3;

			InstanciaSala(linha, coluna, 3);
		}
		else if (numero > 136 && numero <= 168)
		{
			matriz[linha, coluna] = 4;

			InstanciaSala(linha, coluna, 4);
		}
		else
		{
			matriz[linha, coluna] = 5;

			InstanciaSala(linha, coluna, 5);
		}



		if (linha - 1 >= 0)
		{
			if ((matriz[linha - 1, coluna] == -1 && matriz[linha, coluna] > 0))
			{
				RandTile(linha - 1, coluna);
			}
		}

		if (coluna + 1 < largura)
		{
			if ((matriz[linha, coluna + 1] == -1 && matriz[linha, coluna] > 0))
			{
				RandTile(linha, coluna + 1);
			}
		}

		if (linha + 1 < altura)
		{
			if ((matriz[linha + 1, coluna] == -1 && matriz[linha, coluna] > 0))
			{
				RandTile(linha + 1, coluna);
			}
		}

		if (coluna - 1 >= 0)
		{
			if ((matriz[linha, coluna - 1] == -1 && matriz[linha, coluna] > 0))
			{
				RandTile(linha, coluna - 1);
			}
		}
	}
	
	private void InstanciaSala(int linha, int coluna, int sala)
	{
		transformSala.x = 0 - (5 * linha);
		transformSala.y = 0+ (6.4f * coluna);
		transformSala.z = 0;

		GameObject.Instantiate(salas[sala], transformSala, Quaternion.identity);
	}
}

