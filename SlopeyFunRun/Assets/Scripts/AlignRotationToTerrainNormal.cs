using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignRotationToTerrainNormal : MonoBehaviour
{
    public LayerMask terrainLayers;
    public Transform skinToAlign;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactpoints = new ContactPoint[collision.contactCount];
        collision.GetContacts(contactpoints);
        skinToAlign.rotation = Quaternion.LookRotation(skinToAlign.forward, contactpoints[0].normal);
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactpoints = new ContactPoint[collision.contactCount];
        collision.GetContacts(contactpoints);
        skinToAlign.rotation = Quaternion.LookRotation(Vector3.Cross(skinToAlign.right, contactpoints[0].normal), contactpoints[0].normal);
    }

}
