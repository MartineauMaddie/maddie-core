import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function ClassSelect({ classData }) {

  const [selectedClass, setSelectedClass] = React.useState("")
  const classes = classData
  const handleChange = (event) => {
    setSelectedClass(event.target.value);
  };

  return (<FormControl sx={{ m: 1, minWidth: 120 }}>
    <InputLabel id="select-helper-label">Class</InputLabel>
    <Select
      labelId="select-helper-label"
      id="select-helper"
      value={selectedClass}
      label="Class"
      onChange={handleChange}
    >

      {classes.map((charClass) => (
        <MenuItem
          value={charClass.name}
          key={charClass.id}
        >
          {charClass.name}
        </MenuItem>
      ))}

    </Select>

    <hr />
    <p>Your selected class: {selectedClass}</p>

  </FormControl>)
}

