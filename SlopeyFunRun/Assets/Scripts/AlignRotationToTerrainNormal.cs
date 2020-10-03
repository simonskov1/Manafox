using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignRotationToTerrainNormal : MonoBehaviour
{
    public LayerMask terrainLayers;
    public Transform skinToAlign;
    public float maxAngleInDegrees = 80f;
    Rigidbody rb;
    private bool isGrounded;
    public float lerpTime = 1;
    private bool isFirstGrounded = true;
    public GameObject initialCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(isGrounded && isFirstGrounded)
        {
            initialCamera.SetActive(false);
            isFirstGrounded = false;
        }

        if (!isGrounded && rb.velocity == Vector3.zero)
        {
            rb.velocity = skinToAlign.forward;
        }
        else if(!isGrounded)
        {
            Vector3 limitedVelocityVector = new Vector3(rb.velocity.normalized.x, Mathf.Clamp(rb.velocity.normalized.y, -0.30f, 1f), rb.velocity.normalized.z);
            Vector3 lerpedupwardsVector = new Vector3(Mathf.Lerp(skinToAlign.up.x, Vector3.up.x, lerpTime), Mathf.Lerp(skinToAlign.up.y, Vector3.up.y, lerpTime), Mathf.Lerp(skinToAlign.up.z, Vector3.up.z, lerpTime));
            skinToAlign.rotation = Quaternion.LookRotation(limitedVelocityVector, lerpedupwardsVector);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        ContactPoint[] contactpoints = new ContactPoint[collision.contactCount];
        collision.GetContacts(contactpoints);

        float maxAngleInDist = AngleToDist(maxAngleInDegrees);

        float minDistToBoard = float.MaxValue;
        ContactPoint clossestToBoard = new ContactPoint();
        foreach (ContactPoint contact in contactpoints)
        {
            float distToBoard = Vector3.Distance(skinToAlign.up, contact.normal);
            if (distToBoard < minDistToBoard && distToBoard < maxAngleInDist)
            {
                minDistToBoard = distToBoard;
                clossestToBoard = contact;
            }
        }
        if (clossestToBoard.normal != Vector3.zero)
        {
            skinToAlign.rotation = Quaternion.LookRotation(rb.velocity.normalized, clossestToBoard.normal);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactpoints = new ContactPoint[collision.contactCount];
        collision.GetContacts(contactpoints);

        float maxAngleInDist = AngleToDist(maxAngleInDegrees);

        float minDistToBoard = float.MaxValue;
        ContactPoint clossestToBoard = new ContactPoint();
        foreach (ContactPoint contact in contactpoints)
        {
            float distToBoard = Vector3.Distance(skinToAlign.up, contact.normal);
            if (distToBoard < minDistToBoard && distToBoard < maxAngleInDist)
            {
                minDistToBoard = distToBoard;
                clossestToBoard = contact;
            }
        }
        if(clossestToBoard.normal != Vector3.zero)
        {
        skinToAlign.rotation = Quaternion.LookRotation(rb.velocity.normalized, clossestToBoard.normal);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private float AngleToDist(float maxAngle)
    {
        double radiusOfBall = 1;
        return Mathf.Sqrt((float)(Math.Pow(radiusOfBall, 2) + Math.Pow(radiusOfBall, 2) - 2 * radiusOfBall * radiusOfBall * Math.Cos((Math.PI / 180) * maxAngle)));
    }
}
