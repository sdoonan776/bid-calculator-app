<h3 align="center">Bid Calculator App</h3>

---

<p align="center">
    A bid calculator that allows a buyer to calculate the total price of a Common or Luxury vehicle at an auction. The fees are dynamically computed and added to the base price to get the winning bid amount. Built with .NET as the backend webapi, VueJs and Typescript used to build the client SPA, Tailwind for styles, and Xunit for unit tests.
    <br> 
</p>

## 📝 Table of Contents

- [Getting Started](#getting_started)
- [Deployment](#deployment)
- [Usage](#usage)
- [Built Using](#built_using)

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

What things you need to install the software and how to install them.


### Installing
To Build and run the development server for the backend
```
dotnet run --project ./src/BidCalculatorApp/BidCalculatorApp.csproj
```

To build and run the client app 
```
cd ClientApp
npm i
npm run build
serve -s dist
```

## 🔧 Running the tests <a name = "tests"></a>

To run test suite, run:
```
dotnet test  
```

## ⛏️ Built Using <a name = "built_using"></a>

- [.Net](https://dotnet.microsoft.com/en-us/) - Backend Framework
- [VueJs](https://vuejs.org/) - Frontend Framework
- [Tailwind](https://tailwindcss.com/) - CSS Framework
- [XUnit](https://xunit.net/) - Testing Framework


