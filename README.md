MicroService.WebApi.Scaffold
============================

Something to start from when creating a micro service with WebAPI


###Task###

Create an endpoint at http://localhost:9700/bmi/calculate that receives the following example payload as a POST:

```
{
  "height": 1.91,
  "weight": 80
}
```
(weight in kg and height in meters)

and returns the calculated BMI in the following format.

```
{
  "bmi": 21.93,
  "height": 1.91,
  "weight": 80
}
```

using the formula: 
```
BMI = x KG / (y M * y M)
```
```
Where:
x=bodyweight in KG
y=height in m
```
```
Example for 175 cm height und 70 kg weight:
BMI = 70 / (1.75 * 1.75) = 22.86
```

###The solution should###

Implement an application service (with unit tests) to perform the calculation.

Demonstrate IoC to inject the service into the controller.

Round the bmi result to 2 decimal places.



