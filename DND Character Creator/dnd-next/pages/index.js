import React from 'react';
import { useState } from 'react';
import Head from 'next/head'
import Image from 'next/image'


import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';

import Container from '@mui/material/Container';

import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';

import RaceSelect from '@/components/RaceSelect';

export default function Home() {

  const loadData = async () => {
    const BASE_URL = "/api/hello"
    const response = await fetch(`${BASE_URL}`)

    const data = await response.json()
    console.log(data)
    setCharacterData(data)
  }

  const [characterData, setCharacterData] = useState({
    race: "default race",
    description: "empty"
  });

  return (
    <div>
      <Head>
        <title>D&D Character Sheet</title>
        <meta name="description" content="" />
        <link rel="icon" href="/favicon.ico" />
        <link
          rel="stylesheet"
          href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
        />
      </Head>
      <AppBar position="relative">
        <Toolbar>
          <Typography variant="h6" color="inherit" noWrap>
            D&D Character Maker
          </Typography>
        </Toolbar>
      </AppBar>


      <main>
        <Container maxWidth="sm">
          <Box
            sx={{
              bgcolor: 'background.paper',
              pt: 8,
              pb: 6,
            }}
          >
            <Typography variant="h5" align="center" color="text.primary" paragraph>
              Race here: {characterData.race}
            </Typography>
            <Typography
              component="h1"
              variant="h4"
              align="center"
              color="text.secondary"
              gutterBottom
            >
              Description: {characterData.description}
            </Typography>
            <Box
              display="flex"
              justifyContent="center"

            >
              <Button
                variant="contained"
                onClick={loadData}
              >
                Get Data
              </Button>

              <RaceSelect />

            </Box>
          </Box>
        </Container>
      </main>
    </div>
  )

}
