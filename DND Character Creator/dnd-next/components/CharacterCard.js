import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';

export default function CharacterCard({ charLevel, race, charClass }) {

  return (
    <Card sx={{ flexGrow: 1, display: "inline-block", mt:5 }}>
      <CardContent>

        <Typography sx={{ color: 'text', fontSize: 16, display: 'inline-block', }}>
          Level: {charLevel} {race} {charClass}
        </Typography>

        {/* <Typography variant="h5" component="div" >
          {race}
        </Typography>

        <Typography sx={{ fontSize: 14, fontWeight: 300 }}>
          {charClass} 
        </Typography> */}

      </CardContent>
    </Card>
  );
}