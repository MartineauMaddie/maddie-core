//const args = (Deno as any).args as any

let firstName = "maddie" // <-- is the bestest
const args = [
    "4",
    "5",
    "hello world"
]

for (
    let index = 0; 
    index < args.length; 
    index++)
    
    
    {
    const element = args[index];
    console.log("arg"+index, args[index])
}
console.log(typeof args)
console.log("hello word yo")

//declare a variagle with "const" or "let" and dont' use "var"

const width=12  // this i a coment
console.log(width)
console.log('arg0', args[0])
console.log('arg1', args[1])
console.log(typeof width)
console.log(typeof args[0])
const delta=parseFloat(args[0])
console.log(delta)
console.log(typeof delta)
const newwidth=width+delta
console.log(width)
console.log(newwidth)

console.log('hello word yo!!!!')

const howmanytimes=parseInt(args[1],10)
let loopywidth =width

console.log(loopywidth, 'inital value')

for (let index = 0;
     index < howmanytimes;
      index++) {
    // loopywidth = "one sandwhich"
    loopywidth=loopywidth+delta
    console.log(loopywidth)
    if (loopywidth > 30) {
        console.log('its greater than 30')
    } else {
        console.log('its 30 or less')
    }

}


