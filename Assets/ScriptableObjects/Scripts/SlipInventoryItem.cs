using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[CreateAssetMenu(menuName = "SlipInventoryItems/Default", fileName = "DefaultSlipItem")]
public class SlipInventoryItem : AbstractInventoryItem {
    public float slipProbability = 0.1f;
    public float slipRadius = 1f;

    public override void UseItemOnPosition(Vector3 position) {
        CarController carController = FindNearestCarInRadius(position, slipRadius);
        if (carController != null) {
            // TODO
            // give score
            if (Random.Range(0f, 1f) < slipProbability) {
                carController.Slip();
            }
        }
    }

    private CarController FindNearestCarInRadius(Vector3 position, float radius) {
        GameObject[] cars = GameObject.FindGameObjectsWithTag(Constants.Tags.CAR);
        foreach (var car in cars) {
            if (Vector3.Distance(position, car.transform.position) < radius) {
                return car.GetComponent<CarController>();
            }
        }

        return null;
    }
}
