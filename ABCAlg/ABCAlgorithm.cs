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

        public void Solve()
        {
            // Çözümleri ve uygunluk değerlerini tutacak diziler
            var solutions = new double[_colonySize][];
            var fitnessValues = new double[_colonySize];
            var trialCounters = new int[_colonySize];

            // Başlangıç popülasyonunu oluştur
            for (int i = 0; i < _colonySize; i++)
            {
                solutions[i] = GenerateRandomSolution();
                fitnessValues[i] = _objectiveFunction(solutions[i]);
            }

            // En iyi çözümü bul
            int bestIndex = Array.IndexOf(fitnessValues, fitnessValues.Min());
            BestSolution = solutions[bestIndex].ToArray();
            BestFitness = fitnessValues[bestIndex];

            // Ana döngü
            for (int iteration = 0; iteration < _maxIterations; iteration++)
            {
                // İşçi arı fazı
                for (int i = 0; i < _colonySize; i++)
                {
                    var newSolution = GenerateNewSolution(solutions[i], solutions);
                    var newFitness = _objectiveFunction(newSolution);

                    if (newFitness < fitnessValues[i])
                    {
                        solutions[i] = newSolution;
                        fitnessValues[i] = newFitness;
                        trialCounters[i] = 0;

                        // Global en iyi çözümü güncelle
                        if (newFitness < BestFitness)
                        {
                            BestSolution = newSolution.ToArray();
                            BestFitness = newFitness;
                        }
                    }
                    else
                    {
                        trialCounters[i]++;
                    }
                }

                // Gözcü arı fazı
                double[] probabilities = CalculateProbabilities(fitnessValues);
                for (int i = 0; i < _colonySize; i++)
                {
                    if (_random.NextDouble() < probabilities[i])
                    {
                        var newSolution = GenerateNewSolution(solutions[i], solutions);
                        var newFitness = _objectiveFunction(newSolution);

                        if (newFitness < fitnessValues[i])
                        {
                            solutions[i] = newSolution;
                            fitnessValues[i] = newFitness;
                            trialCounters[i] = 0;

                            // Global en iyi çözümü güncelle
                            if (newFitness < BestFitness)
                            {
                                BestSolution = newSolution.ToArray();
                                BestFitness = newFitness;
                            }
                        }
                        else
                        {
                            trialCounters[i]++;
                        }
                    }
                }

                // Keşifçi arı fazı
                for (int i = 0; i < _colonySize; i++)
                {
                    if (trialCounters[i] >= _limit)
                    {
                        solutions[i] = GenerateRandomSolution();
                        fitnessValues[i] = _objectiveFunction(solutions[i]);
                        trialCounters[i] = 0;

                        // Global en iyi çözümü güncelle
                        if (fitnessValues[i] < BestFitness)
                        {
                            BestSolution = solutions[i].ToArray();
                            BestFitness = fitnessValues[i];
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

            // Rastgele bir boyut seç
            int j = _random.Next(_dimension);
            
            // Rastgele bir çözüm seç (kendisi hariç)
            int k;
            do
            {
                k = _random.Next(_colonySize);
            } while (allSolutions[k] == currentSolution);

            // Yeni çözümü oluştur
            double phi = -1 + 2 * _random.NextDouble();
            newSolution[j] = currentSolution[j] + phi * (currentSolution[j] - allSolutions[k][j]);
            
            // Sınırları kontrol et
            newSolution[j] = Math.Max(_lowerBound[j], Math.Min(_upperBound[j], newSolution[j]));

            return newSolution;
        }

        private double[] CalculateProbabilities(double[] fitnessValues)
        {
            double maxFitness = fitnessValues.Max();
            double[] probabilities = new double[_colonySize];
            double sum = 0;

            for (int i = 0; i < _colonySize; i++)
            {
                // Uygunluk değerini normalize et
                probabilities[i] = 1 - (fitnessValues[i] / maxFitness);
                sum += probabilities[i];
            }

            // Olasılıkları normalize et
            for (int i = 0; i < _colonySize; i++)
            {
                probabilities[i] /= sum;
            }

            return probabilities;
        }
    }
} 