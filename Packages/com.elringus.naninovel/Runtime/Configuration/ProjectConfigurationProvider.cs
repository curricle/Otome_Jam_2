using System;
using System.Collections.Generic;
using UnityEngine;

namespace Naninovel
{
    /// <summary>
    /// Default <see cref="IConfigurationProvider"/> implementation providing <see cref="Configuration"/> objects stored as static project assets.
    /// </summary>
    public class ProjectConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// Default path relative to a 'Resources' folder under which the generated configuration assets are stored.
        /// </summary>
        public const string DefaultResourcesPath = "Naninovel/Configuration";

        private readonly Dictionary<Type, Configuration> configObjects = new();
        private static readonly Dictionary<string, Configuration> loadedAssets = new();

        public ProjectConfigurationProvider (string resourcesPath = DefaultResourcesPath)
        {
            foreach (var configType in Engine.Types.Configurations)
            {
                var configAsset = LoadOrDefault(configType, resourcesPath);
                var configObject = UnityEngine.Object.Instantiate(configAsset);
                configObjects.Add(configType, configObject);
            }
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Results are cached, so it's fine to use this method frequently.
        /// </remarks>
        public virtual Configuration GetConfiguration (Type type)
        {
            return configObjects.GetValueOrDefault(type) ?? 
                   throw new Error($"Failed to provide '{type.Name}' configuration object: Requested configuration type not found in project resources.");
        }

        /// <summary>
        /// Attempts to load a configuration asset of the specified type from the project resources.
        /// When the requested configuration asset doesn't exist, will create a default one instead.
        /// </summary>
        /// <typeparam name="TConfig">Type of the requested configuration asset.</typeparam>
        /// <returns>Deserialized version of the requested configuration asset (when exists) or a new default one.</returns>
        public static TConfig LoadOrDefault<TConfig> (string resourcesPath = DefaultResourcesPath)
            where TConfig : Configuration
        {
            return LoadOrDefault(typeof(TConfig), resourcesPath) as TConfig;
        }

        /// <summary>
        /// Same as <see cref="LoadOrDefault{TConfig}"/> but without the type checking.
        /// </summary>
        public static Configuration LoadOrDefault (Type type, string resourcesPath = DefaultResourcesPath)
        {
            var resourcePath = $"{resourcesPath}/{type.Name}";
            if (loadedAssets.TryGetValue(resourcePath, out var result) && result)
                return result;

            var configAsset = Resources.Load(resourcePath, type) as Configuration;

            if (!configAsset)
                configAsset = ScriptableObject.CreateInstance(type) as Configuration;

            return loadedAssets[resourcePath] = configAsset;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ClearCache ()
        {
            loadedAssets.Clear();
        }
    }
}
