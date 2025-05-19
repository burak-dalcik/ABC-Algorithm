using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCAlg
{
    public class ABCAlgorithm
    {
        private readonly Random _random;
        private readonly int _colonySize;
        private readonly int _maxIterations;
        private readonly int _limit;
        private readonly int _dimension;
        private readonly double[] _lowerBound;
        private readonly double[] _upperBound;
        private readonly Func<double[], double> _objectiveFunction;

        public List<double> ConvergenceHistory { get; private set; }
        public double[] BestSolution { get; private set; }
        public double BestFitness { get; private set; }

        public ABCAlgorithm(
            int colonySize,
            int maxIterations,
            int limit,
            int dimension,
            double[] lowerBound,
            double[] upperBound,
            Func<double[], double> objectiveFunction)
        {
            _random = new Random();
            _colonySize = colonySize;
            _maxIterations = maxIterations;
            _limit = limit;
            _dimension = dimension;
            _lowerBound = lowerBound;
            _upperBound = upperBound;
            _objectiveFunction = objectiveFunction;
            ConvergenceHistory = new List<double>();
        }

        private double Fitness(double fx)
        {
            if (fx >= 0)
                return 1.0 / (1.0 + fx);
            else
                return 1.0 + Math.Abs(fx);
        }

        public void Solve()
        {
            var solutions = new double[_colonySize][];
            var fitnessValues = new double[_colonySize];
            var objectiveValues = new double[_colonySize];
            var trialCounters = new int[_colonySize];

            // Başlangıç
            for (int i = 0; i < _colonySize; i++)
            {
                solutions[i] = GenerateRandomSolution();
                objectiveValues[i] = _objectiveFunction(solutions[i]);
                fitnessValues[i] = Fitness(objectiveValues[i]);
            }

            int bestIndex = Array.IndexOf(objectiveValues, objectiveValues.Min());
            BestSolution = solutions[bestIndex].ToArray();
            BestFitness = objectiveValues[bestIndex];

            for (int iteration = 0; iteration < _maxIterations; iteration++)
            {
                // İşçi arı
                for (int i = 0; i < _colonySize; i++)
                {
                    var newSolution = GenerateNewSolution(solutions[i], solutions);
                    double newObj = _objectiveFunction(newSolution);
                    double newFit = Fitness(newObj);

                    if (newFit > fitnessValues[i])
                    {
                        solutions[i] = newSolution;
                        objectiveValues[i] = newObj;
                        fitnessValues[i] = newFit;
                        trialCounters[i] = 0;
                        if (newObj < BestFitness)
                        {
                            BestSolution = newSolution.ToArray();
                            BestFitness = newObj;
                        }
                    }
                    else
                    {
                        trialCounters[i]++;
                    }
                }

                // Gözcü arı
                double[] probabilities = CalculateProbabilities(fitnessValues);
                for (int i = 0; i < _colonySize; i++)
                {
                    if (_random.NextDouble() < probabilities[i])
                    {
                        var newSolution = GenerateNewSolution(solutions[i], solutions);
                        double newObj = _objectiveFunction(newSolution);
                        double newFit = Fitness(newObj);

                        if (newFit > fitnessValues[i])
                        {
                            solutions[i] = newSolution;
                            objectiveValues[i] = newObj;
                            fitnessValues[i] = newFit;
                            trialCounters[i] = 0;
                            if (newObj < BestFitness)
                            {
                                BestSolution = newSolution.ToArray();
                                BestFitness = newObj;
                            }
                        }
                        else
                        {
                            trialCounters[i]++;
                        }
                    }
                }

                // Kaşif arı
                for (int i = 0; i < _colonySize; i++)
                {
                    if (trialCounters[i] >= _limit)
                    {
                        solutions[i] = GenerateRandomSolution();
                        objectiveValues[i] = _objectiveFunction(solutions[i]);
                        fitnessValues[i] = Fitness(objectiveValues[i]);
                        trialCounters[i] = 0;
                        if (objectiveValues[i] < BestFitness)
                        {
                            BestSolution = solutions[i].ToArray();
                            BestFitness = objectiveValues[i];
                        }
                    }
                }

                ConvergenceHistory.Add(BestFitness);
            }
        }

        private double[] GenerateRandomSolution()
        {
            var solution = new double[_dimension];
            for (int i = 0; i < _dimension; i++)
            {
                solution[i] = _lowerBound[i] + _random.NextDouble() * (_upperBound[i] - _lowerBound[i]);
            }
            return solution;
        }

        private double[] GenerateNewSolution(double[] currentSolution, double[][] allSolutions)
        {
            var newSolution = new double[_dimension];
            Array.Copy(currentSolution, newSolution, _dimension);
            int j = _random.Next(_dimension);
            int k;
            do
            {
                k = _random.Next(_colonySize);
            } while (allSolutions[k] == currentSolution);
            double phi = -1 + 2 * _random.NextDouble();
            newSolution[j] = currentSolution[j] + phi * (currentSolution[j] - allSolutions[k][j]);
            newSolution[j] = Math.Max(_lowerBound[j], Math.Min(_upperBound[j], newSolution[j]));
            return newSolution;
        }

        private double[] CalculateProbabilities(double[] fitnessValues)
        {
            double sum = fitnessValues.Sum();
            double[] probabilities = new double[_colonySize];
            for (int i = 0; i < _colonySize; i++)
                probabilities[i] = fitnessValues[i] / sum;
            return probabilities;
        }
    }
} 