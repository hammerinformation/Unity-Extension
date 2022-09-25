using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

//https://github.com/hammerinformation?tab=repositories
public static class Extension
{
    public static bool IsChildGameObject(this GameObject gameObject) => gameObject.transform.parent ? true : false;
    public static bool IsAttachedTo(this GameObject gameObject, GameObject target) => gameObject.transform.parent == target.transform ? true : false;
    public static GameObject GetParent(this GameObject gameObject) => gameObject.transform.parent.gameObject;
    public static void Lerp(this GameObject gameObject, GameObject target, float t)
    {

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position, t);
    }
    public static void SLerp(this GameObject gameObject, GameObject target, float t)
    {

        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, target.transform.position, t);
    }
    public static void MoveTowards(this GameObject gameObject, GameObject target, float maxDistanceDelta)
    {

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, maxDistanceDelta);
    }
    public static float GetDistanceTo(this GameObject gameObject, GameObject otherGameObject) => Vector3.Distance(gameObject.transform.position, otherGameObject.transform.position);
    public static float GetDotProductTo(this GameObject gameObject, GameObject otherGameObject) => Vector3.Dot(gameObject.transform.position, otherGameObject.transform.position);
    public static Vector3 GetCrossTo(this GameObject gameObject, GameObject otherGameObject) => Vector3.Cross(gameObject.transform.position, otherGameObject.transform.position);
    public static void Print(this GameObject gameObject, string message)
    {

        Debug.Log(message);

    }
    public static GameObject Spawn(this GameObject gameObject, GameObject g, Vector3 pos, Quaternion rot) => Object.Instantiate(g, pos, rot);
    public static void SetGlobalRotation(this GameObject gameObject, Quaternion rotation)
    {
        gameObject.transform.rotation = rotation;

    }
    public static void SetLocalRotation(this GameObject gameObject, Quaternion rotation)
    {
        gameObject.transform.localRotation = rotation;

    }
    public static void SetParent(this GameObject gameObject, Transform parent)
    {
        gameObject.transform.SetParent(parent);

    }
    public static void SetGlobalPosition(this GameObject gameObject, Vector3 position)
    {
        gameObject.transform.position = position;
    }
    public static void AddGlobalPosition(this GameObject gameObject, Vector3 position)
    {
        gameObject.transform.position += position;
    }
    public static void SetLocalPosition(this GameObject gameObject, Vector3 position)
    {
        gameObject.transform.localPosition = position;
    }
    public static void AddLocalPosition(this GameObject gameObject, Vector3 position)
    {
        gameObject.transform.localPosition += position;
    }
    public static Vector3 GetLocalScale(this GameObject gameObject) => gameObject.transform.localScale;
    public static Vector3 GetGlobalScale(this GameObject gameObject) => gameObject.transform.lossyScale;
    public static Rigidbody GetRigidbody(this GameObject gameObject) => gameObject.GetComponent<Rigidbody>() ? gameObject.GetComponent<Rigidbody>() : gameObject.AddComponent<Rigidbody>();
    public static BoxCollider GetBoxCollider(this GameObject gameObject) => gameObject.GetComponent<BoxCollider>() ? gameObject.GetComponent<BoxCollider>() : gameObject.AddComponent<BoxCollider>();
    public static GameObject FindNearestGameObjectWithTag(this GameObject gameObject, string tag)
    {
        List<GameObject> gameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        float distance = 99999999.0f;
        GameObject g = null;
        foreach (var item in gameObjects)
        {
            float d = Vector3.Distance(gameObject.transform.position, item.transform.position);
            if (d < distance)
            {
                distance = d;
                g = item;
            }
        }


        return g;

    }
    public static List<GameObject> GetChildren(this GameObject gameObject)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform item in gameObject.transform)
        {
            children.Add(item.gameObject);
        }
        return children;
    }
    public static GameObject GettingGameobjectFromRaycastHit(this GameObject gameObject, GameObject target)
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, target.transform.position - gameObject.transform.position, out hit, Mathf.Infinity);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
    public static NavMeshAgent GetNavMeshAgent(this GameObject gameObject) => gameObject.GetComponent<NavMeshAgent>() ? gameObject.GetComponent<NavMeshAgent>() : gameObject.AddComponent<NavMeshAgent>();
    public static CapsuleCollider GetCapsuleCollider(this GameObject gameObject) => gameObject.GetComponent<CapsuleCollider>() ? gameObject.GetComponent<CapsuleCollider>() : gameObject.AddComponent<CapsuleCollider>();
    public static SphereCollider GetSphereCollider(this GameObject gameObject) => gameObject.GetComponent<SphereCollider>() ? gameObject.GetComponent<SphereCollider>() : gameObject.AddComponent<SphereCollider>();
    public static Collider GetCollider(this GameObject gameObject) => gameObject.GetComponent<Collider>() ? gameObject.GetComponent<Collider>() : gameObject.AddComponent<Collider>();
    public static MeshCollider GetMeshCollider(this GameObject gameObject) => gameObject.GetComponent<MeshCollider>() ? gameObject.GetComponent<MeshCollider>() : gameObject.AddComponent<MeshCollider>();
    public static MeshRenderer GetMeshRenderer(this GameObject gameObject) => gameObject.GetComponent<MeshRenderer>() ? gameObject.GetComponent<MeshRenderer>() : gameObject.AddComponent<MeshRenderer>();
    public static SkinnedMeshRenderer GetSkinnedMeshRenderer(this GameObject gameObject) => gameObject.GetComponent<SkinnedMeshRenderer>() ? gameObject.GetComponent<SkinnedMeshRenderer>() : gameObject.AddComponent<SkinnedMeshRenderer>();
    public static Animator GetAnimatorr(this GameObject gameObject) => gameObject.GetComponent<Animator>() ? gameObject.GetComponent<Animator>() : gameObject.AddComponent<Animator>();
    public static void DestroyRigidbody(this GameObject gameObject)
    {
        if (gameObject.GetComponent<Rigidbody>())
        {
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
        }
    }
    public static void DestroyCollider(this GameObject gameObject)
    {
        if (gameObject.GetComponent<Collider>())
        {
            Object.Destroy(gameObject.GetComponent<Collider>());
        }
    }
    public static void SetAnimatorSpeed(this GameObject gameObject, float speed)
    {
        if (gameObject.GetComponent<Animator>())
        {
            gameObject.GetComponent<Animator>().speed = speed;
        }
    }
    public static void CircleMovement(this GameObject gameObject, float frequency, float amplitude)
    {

        float x = Mathf.Cos(Time.time * frequency) * amplitude;
        float z = Mathf.Sin(Time.time * frequency) * amplitude;
        var pos = gameObject.transform.position;
        var targetPos = new Vector3(pos.x + x, pos.y, pos.z + z);
        gameObject.transform.position = targetPos;

    }
    public static void AddMovement(this GameObject gameObject, Vector3 vector3)
    {
        gameObject.transform.position = gameObject.transform.position + vector3;
    }
    public static void ResetAllTransform(this GameObject gameObject)
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localScale = Vector3.one;
    }
    public static Vector3 GetRigidbodyVelocity(this GameObject gameObject) => (gameObject.GetComponent<Rigidbody>()) ? gameObject.GetComponent<Rigidbody>().velocity : Vector3.zero;
    public static void SetMaterial(this GameObject gameObject, int index, Material material)
    {
        if (gameObject.GetComponent<MeshRenderer>())
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            var materials = meshRenderer.materials;
            materials[index] = material;
            meshRenderer.materials = materials;
        }
        else
        {

            if (gameObject.GetComponent<SkinnedMeshRenderer>())
            {
                SkinnedMeshRenderer meshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
                var materials = meshRenderer.materials;
                materials[index] = material;
                meshRenderer.materials = materials;
            }
        }

    }

   


}
