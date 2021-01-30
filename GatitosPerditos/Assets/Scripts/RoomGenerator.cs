using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject []salas;

	[SerializeField]
	private float alturaSala, larguraSala;

	[SerializeField]
	private int altura, largura;

	private int[,] matriz;

	private int xMeio;
	private int yMeio;

	private int salasViaveis;

	private Vector3 transformSala;



    void Start()
    {
		salasViaveis = 0;
		xMeio = altura / 2;
		yMeio = largura / 2;

        matriz = new int[altura, largura];

		while(salasViaveis < 12)
		{
			salasViaveis = 0;
			IniciarMatriz();
			RandTile(xMeio, yMeio);
			VerificaNumeroSalas();
		}

		for(int i = 0; i < altura; i++)
		{
			for(int j = 0; j < largura; j++)
			{
				

				InstanciaSala(i, j, matriz[i, j]);
					
			}
		}




    }

    private void RandTile(int linha, int coluna)
	{
		int numero;
		float maxSala;


		maxSala = salas.Length;

		maxSala = maxSala *1.2f;
		
		

		if (xMeio == linha && yMeio == coluna)
		{
			numero = Random.Range(1, salas.Length - 1);
		}
		else
		{
			numero = Random.Range(1,(int)maxSala);
			Debug.Log(numero + " " + linha + ", " + coluna);
		}

		if(numero > salas.Length-1)
		{
			matriz[linha, coluna] = 0;
		}
		else
		{
			matriz[linha, coluna] = numero;
			
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
		transformSala.x = 0 + (larguraSala * coluna);
		transformSala.y = 0 - (alturaSala * linha);
		transformSala.z = 0;

		GameObject aux;
		aux = GameObject.Instantiate(salas[sala], transformSala, Quaternion.identity);
		aux.GetComponentInChildren<RoomStats>().id = new Vector2(linha,coluna);
	}

	private void VerificaNumeroSalas()
	{
		foreach (int numeroSala  in matriz)
		{
			if (numeroSala >= 1 && numeroSala <= 5)
			{
				salasViaveis++;
			}
		}
	}

	private void IniciarMatriz()
	{
		for (int i = 0; i < largura; i++)
		{
			matriz[0, i] = 0;
			matriz[altura - 1, i] = 0;
		}
		for (int i = 0; i < altura; i++)
		{
			matriz[i, 0] = 0;
			matriz[i, largura - 1] = 0;

		}
		for (int i = 1; i < altura - 1; i++)
		{
			for (int j = 1; j < largura - 1; j++)
			{
				matriz[i, j] = -1;
			}
		}
	}

	private void InitializeObjects()
	{

	}
}

