import React, { useEffect, useState } from "react";
import { Container, Form, FormGroup, Label, Input, Button, Col, Collapse, ListGroup, ListGroupItem, Badge } from "reactstrap";
import { useLogin } from '../hooks/Login';
import { categoriasLista, categoriesEnum } from '../utils/constants';
import { toBase64 } from '../services/base64';

export const TelaTDP = () => {
  const { user } = useLogin()
  console.log('user:',user)
  const [arquivo, setArquivo] = useState(null);
  const [categoriasSelecionada, setCategoriasSelecionada] = useState(null);
  const [categoriasDaEquipe, setCategoriasDaEquipe] = useState([]);

  useEffect(() => {
    async function fetchEventos() {
      fetch("/api/evento", {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => response.json())
        .then((data) => {
          if (data) {
            // console.log({data})
            for(const evento of data) {
              // console.log(evento)
              const equipeInscrita = evento.equipes.find(equipe => equipe.equipeId === user.equipe.id)
              // console.log({equipeInscrita})
              if(equipeInscrita) {
                // console.log('categorias',equipeInscrita.categorias)
                setCategoriasDaEquipe(equipeInscrita.categorias)
                break
              }

            }
          } else {
            // Show an error message
            alert(data.error);
          }
        })
        .catch(() => {
          alert("OPS, ALGO DEU ERRADO AO PUXAR EVENTOS");
        });
    }
    fetchEventos();
  }, []);

  const handleFileChange = (e) => {
    e.preventDefault();
    const selectedFile = e.target.files[0];
    setArquivo(selectedFile);
  };

  const handleUpload = async (e) => {
    e.preventDefault();
    if (!user?.equipe) {
      alert('Você não está cadastrado numa equipe')
    }
    if (arquivo) {
      console.log("Arquivo selecionado:", arquivo);
      try {
        await fetch("/api/tdp", {
          method: "POST",
          headers: {
            "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
          },
          body: JSON.stringify({
            "EquipeId" : user.equipe.id,
            "Categoria" : categoriasSelecionada,
            "Arquivo" : await toBase64(arquivo),
            "UltimaVezModificado" : arquivo.lastModifiedDate
          }),
        });
        alert('TDp Enviado')
      } catch (error) {
        console.error("Erro na requisição PATCH:", error);
        alert("OPS, ALGO DEU ERRADO AO ENVIAR TDP");
      }
    }
  };

  return (
    <Container>
      <Col
        md={{
          size: 12,
        }}
      >
      <h2>Enviar Arquivo</h2>
      <Collapse isOpen={!user?.equipe}>
        <p>Você não está cadastrado em nenhuma equipe</p>
      </Collapse>
      <Collapse isOpen={categoriasDaEquipe.length <= 0}>
        <p>Sua equipe não está em nenhum evento</p>
      </Collapse>
      <Form>
        <FormGroup>
          <Label for="arquivo">Selecione o arquivo</Label>
          <Input
            type="file"
            name="arquivo"
            id="arquivo"
            onChange={handleFileChange}
            required
          />
        </FormGroup>
        <FormGroup >
          <Label for="Categoria">Categoria</Label>
          <ListGroup horizontal>
            {categoriasDaEquipe.map((categoria) => (
              <ListGroupItem
                key={categoria}
                tag="div"
                onClick={() => setCategoriasSelecionada(categoria)}
                active={categoriasSelecionada === categoria}
              >
                <Badge color="secondary" style={{ marginLeft: 8 }}>
                  {categoriesEnum[categoria]}
                </Badge>
              </ListGroupItem>
            ))}
          </ListGroup>
        </FormGroup>
        <Button color="primary" onClick={handleUpload} disabled={!categoriasSelecionada || !arquivo}>
          Enviar
        </Button>
      </Form>
      </Col>
    </Container>
  );
};
