import React from 'react'
import GoogleLogin from 'react-google-login';
import { Col, Container } from 'reactstrap';
import { useLogin } from '../hooks/Login';
import { useNavigate } from 'react-router-dom';

export function Login() {
  const { setUser } = useLogin()
  const navigate = useNavigate()
  async function onSuccess(data) {
    try {
      const response = await fetch(`/api/Login/${data.googleId}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json", // Define o tipo de conteúdo como JSON
        }
      });

      if (!response.ok) {
        throw new Error("Erro na requisição");
      }

      const responseData = await response.json(); // Parse da resposta para JSON
      setUser(responseData)
      navigate('/tela-evento')
    } catch (error) {
      console.error("Erro na requisição POST:", error);
      alert("OPS, ALGO DEU ERRADO");
    }
  }

  return (
    <Container>
      <Col
        md={{
          offset: 3,
          size: 6
        }}
        sm="12"
      >
        <GoogleLogin
          clientId={process.env.REACT_APP_GOOGLE_CLIENT_ID}
          buttonText="Registre-se com Google"
          onSuccess={onSuccess}
          // onFailure={responseGoogle}
          cookiePolicy={'single_host_origin'}
        />
      </Col>
    </Container>
  )
}
