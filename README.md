# AssetLoadingRobotLegs

## Using downloader
    .Install(typeof(DownloadingExtension))
    .Configure(new DownloadingConfig().WithRootDownloadLocation(Application.persistentDataPath))


    dispatcher.Dispatch(new DownloadRequestEvent(DownloadRequestEvent.Type.DownloadRequest, String[], Action, String));

## Using asset loader
    .Install(typeof(AssetLoadingExtension))
    .Configure(new AssetProcessorConfig().WithRootLocation(Application.persistentDataPath))

    dispatcher.Dispatch(new AssetLoadEvent(AssetLoadEvent.Type.AssetProcessEvent, Action, Object, String));