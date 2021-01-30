using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject []salas;
	[SerializeField]
    private GameObject []objects;

	[SerializeField]
	private float alturaSala, larguraSala;

	[SerializeField]
	private int altura, largura;

	private int[,] matriz;

	private int xMeio;
	private int yMeio;

	private int salasViaveis;

	private Vector3 transformSala;


	private Vector3 positionObject;
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


		InitializeObjects();

    }

    private void RandTile(int linha, int coluna)
	{
		int numero,intMaxSala;
		float maxSala;
		


		maxSala = salas.Length;

		maxSala = maxSala *1.2f;
		
		intMaxSala = (int)maxSala;

		if (xMeio == linha && yMeio == coluna)
		{
			numero = Random.Range(1, salas.Length - 1);
		}
		else
		{
			numero = Random.Range(1,intMaxSala);
			
		}

		

		// if(numero < salas.Length-2 && numero < 0)
		// {
		// 	matriz[linha, coluna] = 0;
		// }
		// else
		// {
		// 	Debug.Log(numero);
		// 	matriz[linha, coluna] = numero;
			
		// }

		if(numero > salas.Length-2)
		{
			matriz[linha, coluna] = 0;
		}		
		else if(numero <= 0)
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


		if(sala != -1)
		{
			GameObject aux;
			aux = GameObject.Instantiate(salas[sala], transformSala, Quaternion.identity);
			aux.GetComponentInChildren<RoomStats>().id = new Vector2(linha,coluna);
		}

		
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
		int xpos,ypos;
		GameObject p1,p2;

		
		
		for (int i = 0; i < objects.Length -2; i++)
		{
			do
			{
				xpos = Random.Range(1,altura-1);
				ypos = Random.Range(1,largura-1);

				//Debug.Log(matriz[xpos,ypos]);

			} while (matriz[xpos,ypos] < 0);

			matriz[xpos,ypos] = -1;

			positionObject.x = (larguraSala * ypos);
			positionObject.y = -(alturaSala * xpos);
			positionObject.z = 0;

			GameObject.Instantiate(objects[i],positionObject,Quaternion.identity);

		}

		do
		{
			xpos = Random.Range(1,altura-1);
			ypos = Random.Range(1,largura-1);
			//Debug.Log(matriz[xpos,ypos]);
		} while (matriz[xpos,ypos] <= 0);

		matriz[xpos,ypos] = -1;

		positionObject.x = (larguraSala * ypos);
		positionObject.y = -(alturaSala * xpos);
		positionObject.z = 0;

		p1 = GameObject.Instantiate(objects[10],positionObject,Quaternion.identity);

		do
		{
			xpos = Random.Range(1,altura-1);
			ypos = Random.Range(1,largura-1);
			//Debug.Log(matriz[xpos,ypos]);

		} while (matriz[xpos,ypos] <= 0);

		matriz[xpos,ypos] = -1;

		positionObject.x = (larguraSala * ypos);
		positionObject.y = -(alturaSala * xpos);
		positionObject.z = 0;

		p2 = GameObject.Instantiate(objects[11],positionObject,Quaternion.identity);

		p1.transform.GetComponentInChildren<MovementTest>().otherPlayer = p2.transform.GetChild(1).gameObject;
		p2.transform.GetComponentInChildren<MovementTest>().otherPlayer = p1.transform.GetChild(1).gameObject;

	}
}

