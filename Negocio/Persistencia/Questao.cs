﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionario.Negocio.Entidade;

namespace Questionario.Negocio.Persistencia
{
    public class Questao
    {
        private static QuestaoInstancia instancia;

        private Questao() { }

        public static QuestaoInstancia InstanciaQuestao()
        {
            if(instancia == null)
            {
                return new QuestaoInstancia();
            }
            return instancia;
        }

        public  class QuestaoInstancia
        {
            private List<Negocio.Entidade.Questao> Questoes = new List<Negocio.Entidade.Questao>() {

                new Negocio.Entidade.Questao()
                {
                    ID = 1,
                    Resposta="A"
                },
                 new Negocio.Entidade.Questao()
                {
                    ID = 2,
                    Resposta="B"
                }
            };

            public QuestaoInstancia() { }

            public List<Negocio.Entidade.Questao> Lista()
            {
                return Questoes;
            }

            public void Salva(Negocio.Entidade.Questao questao)
            {
                Questoes.Add(questao);
            }

            public bool Deleta(int questaoId)
            {
                var questao = Pesquisa(questaoId);
                try
                {
                    if(questao == null)
                    {
                        return false;
                    }
                    Questoes.Remove(questao);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public bool Atualiza(Negocio.Entidade.Questao questao)
            {
                var questaoSalva = Pesquisa(questao.ID);
                if(questaoSalva == null)
                {
                    return false;
                }
                questaoSalva = questao;
                return true;
            }

            public Entidade.Questao Pesquisa(int questaoId)
            {
                return Questoes.Where(questaoSalva => questaoSalva.ID == questaoId).FirstOrDefault();
            }
        }
    }
}
