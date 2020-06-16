using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class trainingset
{
    public double[] input;
    public double output;
}

public class perceptron : MonoBehaviour
{
    public trainingset[] ts;
    public double[] weights = { 0, 0 };
    double bias;
    double totalerror = 0;

    public void setrandom()
    {
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1f, 1f);
        }
        bias = Random.Range(-1f, 1f);
    }
    public void train(int epoch)
    {
        setrandom();
        for (int i = 0; i < epoch; i++)
        {
            totalerror = 0;
            for (int j = 0; j < ts.Length; j++)
            {
                updateweight(j);
                Debug.Log("W1 : " + weights[0] + " W2 : " + weights[1] + " bias" + bias);
            }
            Debug.Log("Total Error : " + totalerror);
        }
    }
    public void updateweight(int i)
    {
        double error = ts[i].output - calcOutput(i);
        totalerror += Mathf.Abs((float)error);
        for (int j = 0; j < weights.Length; j++)
        {
            weights[j] = weights[j] + error * ts[i].input[j];
        }
        bias += error;

    }
    public double calcOutput(int i)
    {
        double value = dotproductevaluate(weights, ts[i].input);
        if (value > 0) return 1;
        return 0;
    }
    public double dotproductevaluate(double[] weight, double[] input)
    {
        if (weight == null || input == null)
            return -1;
        if (weight.Length != input.Length)
            return -1;
        double db=0;
        for(int i=0;i<weight.Length;i++)
        {
            db += weight[i] * input[i];
        }
        db += bias;
        return db;
    }
    double test(double i1,double i2)
    {
        double[] ip = new double[] { i1, i2 };
        double dp = dotproductevaluate(weights, ip);
        if (dp > 0)
            return 1;
        else
            return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        train(8);
        Debug.Log("Test 1 : " + test(0, 0));
        Debug.Log("Test 1 : " + test(0, 1));
        Debug.Log("Test 1 : " + test(1, 0));
        Debug.Log("Test 1 : " + test(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
