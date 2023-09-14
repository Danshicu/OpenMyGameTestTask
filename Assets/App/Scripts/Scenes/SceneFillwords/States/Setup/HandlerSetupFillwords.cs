using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Infrastructure.LevelSelection;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels.View.ViewGridLetters;
using App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel;

namespace App.Scripts.Scenes.SceneFillwords.States.Setup
{
    public class HandlerSetupFillwords : IHandlerSetupLevel
    {
        private readonly ContainerGrid _containerGrid;
        private readonly IProviderFillwordLevel _providerFillwordLevel;
        private readonly IServiceLevelSelection _serviceLevelSelection;
        private readonly ViewGridLetters _viewGridLetters;
        private int offset = 0;
        private int countOfLevels;

        public HandlerSetupFillwords(IProviderFillwordLevel providerFillwordLevel,
            IServiceLevelSelection serviceLevelSelection,
            ViewGridLetters viewGridLetters, ContainerGrid containerGrid)
        {
            _providerFillwordLevel = providerFillwordLevel;
            _serviceLevelSelection = serviceLevelSelection;
            _viewGridLetters = viewGridLetters;
            _containerGrid = containerGrid;
            countOfLevels = StringReader.GetStringCount("Assets/App/Resources/Fillwords/pack_0.txt");
        }

        public Task Process()
        {
            int logicalLevel = _serviceLevelSelection.CurrentLevelIndex + offset;
            var model = _providerFillwordLevel.LoadModel(logicalLevel/(countOfLevels+1)+logicalLevel%(countOfLevels+1));
            while (model == null)
            {
                logicalLevel++;
                offset++;
                model = _providerFillwordLevel.LoadModel(logicalLevel/(countOfLevels+1)+logicalLevel%(countOfLevels+1));
            }

            // if (_serviceLevelSelection.CurrentLevelIndex == countOfLevels)
            // {
            //     offset++;
            // }
            _viewGridLetters.UpdateItems(model);
            _containerGrid.SetupGrid(model, _serviceLevelSelection.CurrentLevelIndex);
            return Task.CompletedTask;
        }
    }
}