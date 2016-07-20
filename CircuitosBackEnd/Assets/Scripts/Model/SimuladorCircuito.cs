using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SimuladorCircuito{

	private string caminho = "/home/italo-ubglts16/Documents/";
	private Circuito circuito;

	public SimuladorCircuito(Circuito target) {
		this.circuito = target;

	}

	public void gerarNetlist(){
		/* Gera uma Netlist com as seguintes informacoes:
		 * 
		 * Cabecalho
		 * nome no+ no- {tipo} valor
		 * ...
		 * Linha final
		 * 
		 */
		StreamWriter wr = new StreamWriter (
			caminho + circuito.nome + ".cir");
		foreach (var item in circuito.componentes) {
			if (item.tipo.Equals (
				ComponenteEletrico.Tipos.Resistor)) {
				wr.WriteLine (
					item.nome + " " +
					item.noPositivo.ToString () + " " +
					item.noNegativo.ToString () + " " +
					item.valor.ToString ()
				);
			} else if (item.tipo.Equals (
				ComponenteEletrico.Tipos.FonteDC)) {
				wr.WriteLine (
					item.nome + " " +
					item.noPositivo.ToString () + " " +
					item.noNegativo.ToString () + " " +
					"dc " +
					item.valor.ToString ()
				);
			}
		}
		wr.Close ();
	}
	public void lerNetList() {
		/*Preenche circuitos com dados de uma netlist
		 */
		circuito.componentes.Clear ();

		//TODO: Esse caminho+nome abre possibilidade pra erros, melhorar
		StreamReader arquivo = new StreamReader(caminho + circuito.nome + ".cir");
		string linhaLida;

		while ((linhaLida = arquivo.ReadLine()) != null) {

			var dadosLidos = linhaLida.Split(' ');
			//Verifica se tem os campos: nome no1 no2 valor
			if (dadosLidos.Length >= 4) {

				var componente = new ComponenteEletrico {
					nome = dadosLidos [0],
					noPositivo = Convert.ToInt32 (dadosLidos [1]),
					noNegativo = Convert.ToInt32 (dadosLidos [2]),
					valor = Convert.ToDouble (
						dadosLidos [dadosLidos.Length - 1])
				};

				//Se tbm tem 1 campo a mais
				if (dadosLidos.Length == 5) {
					if (dadosLidos [3].Equals ("dc")) {
						componente.tipo = ComponenteEletrico.Tipos.FonteDC;
					}
				}

				circuito.componentes.Add (componente);
			}
		}
		arquivo.Close();

	}
}
