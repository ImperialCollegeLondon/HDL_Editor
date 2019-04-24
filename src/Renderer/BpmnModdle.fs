// ts2fable 0.0.0
module rec BpmnModdle
open System
open Fable.Core
open Fable.Import.JS

let [<Import("BPMNModdle","bpmn-moddle")>] BPMNModdle: BPMNModdle.BPMNModdleConstructor = jsNative

module BPMNModdle =

    type [<AllowNullLiteral>] IExports =
        abstract BPMNModdleConstructor: BPMNModdleConstructorStatic

    type [<StringEnum>] [<RequireQualifiedAccess>] AdHocOrdering =
        | [<CompiledName "Parallel">] Parallel
        | [<CompiledName "Sequential">] Sequential

    type [<StringEnum>] [<RequireQualifiedAccess>] AssociationDirection =
        | [<CompiledName "None">] None
        | [<CompiledName "One">] One
        | [<CompiledName "Both">] Both

    type [<StringEnum>] [<RequireQualifiedAccess>] ChoreographyLoopType =
        | [<CompiledName "None">] None
        | [<CompiledName "Standard">] Standard
        | [<CompiledName "MultiInstanceSequential">] MultiInstanceSequential
        | [<CompiledName "MultiInstanceParallel">] MultiInstanceParallel

    type [<StringEnum>] [<RequireQualifiedAccess>] EventBasedGatewayType =
        | [<CompiledName "Parallel">] Parallel
        | [<CompiledName "Exclusive">] Exclusive

    type [<StringEnum>] [<RequireQualifiedAccess>] GatewayDirection =
        | [<CompiledName "Unspecified">] Unspecified
        | [<CompiledName "Converging">] Converging
        | [<CompiledName "Diverging">] Diverging
        | [<CompiledName "Mixed">] Mixed

    type [<StringEnum>] [<RequireQualifiedAccess>] ItemKind =
        | [<CompiledName "Physical">] Physical
        | [<CompiledName "Information">] Information

    type [<StringEnum>] [<RequireQualifiedAccess>] MultiInstanceBehaviour =
        | [<CompiledName "None">] None
        | [<CompiledName "One">] One
        | [<CompiledName "All">] All
        | [<CompiledName "Complex">] Complex

    type [<StringEnum>] [<RequireQualifiedAccess>] ProcessType =
        | [<CompiledName "None">] None
        | [<CompiledName "Public">] Public
        | [<CompiledName "Private">] Private

    type [<StringEnum>] [<RequireQualifiedAccess>] RelationshipDirection =
        | [<CompiledName "None">] None
        | [<CompiledName "Forward">] Forward
        | [<CompiledName "Backward">] Backward
        | [<CompiledName "Both">] Both

    type [<AllowNullLiteral>] TypeDerived =
        abstract ``$type``: ElementType with get, set
        abstract ``$parent``: TypeDerived with get, set

    type [<AllowNullLiteral>] BaseElement =
        inherit TypeDerived
        /// Is the primary Id of the element
        abstract id: string with get, set
        /// Documentation for the element
        abstract documentation: ResizeArray<Documentation> option with get, set
        /// Reference to the extension definitions for this element
        abstract extensionDefinitions: ResizeArray<ExtensionDefinition> option with get, set
        /// Extension Elements
        abstract extensionElements: ExtensionElements option with get, set
        /// Attributes that aren't defined by the BPMN Spec such
        /// as Camunda properties
        abstract ``$attrs``: TypeLiteral_01 option with get, set

    type [<AllowNullLiteral>] RootElement =
        inherit BaseElement

    type [<AllowNullLiteral>] Interface =
        inherit RootElement
        abstract name: string with get, set
        abstract operations: ResizeArray<Operation> with get, set
        abstract implementationRef: string with get, set

    type [<AllowNullLiteral>] Operation =
        inherit BaseElement
        abstract name: string with get, set
        abstract inMessageRef: Message with get, set
        abstract outMessageRef: Message with get, set
        abstract errorRef: ErrorElement with get, set
        abstract implementationRef: string with get, set

    type [<AllowNullLiteral>] EndPoint =
        inherit RootElement

    type [<AllowNullLiteral>] Auditing =
        inherit BaseElement

    type [<AllowNullLiteral>] CallableElement =
        inherit RootElement
        abstract name: string with get, set
        abstract ioSpecification: InputOutputSpecification with get, set
        abstract supportedInterfaceRef: Interface with get, set
        abstract ioBinding: InputOutputBinding with get, set

    type [<AllowNullLiteral>] ResourceRole =
        inherit BaseElement
        abstract name: string with get, set
        abstract resourceRef: Resource with get, set
        abstract ResourceParameterBindings: ResizeArray<ResourceParameterBinding> with get, set
        abstract resourceAssignmentExpression: ResourceAssignmentExpression with get, set

    type [<AllowNullLiteral>] GlobalTask =
        inherit CallableElement
        abstract resources: ResourceRole with get, set

    type [<AllowNullLiteral>] Monitoring =
        inherit BaseElement

    type [<AllowNullLiteral>] Performer =
        inherit ResourceRole

    type [<AllowNullLiteral>] Process =
        inherit FlowElementsContainer
        inherit CallableElement
        abstract processType: string with get, set
        abstract isClosed: bool with get, set
        abstract auditing: Auditing with get, set
        abstract monitoring: Monitoring with get, set
        abstract properties: ResizeArray<Property> with get, set
        abstract laneSets: ResizeArray<LaneSet> with get, set
        abstract flowElements: ResizeArray<FlowElement> with get, set
        abstract artifacts: ResizeArray<Artifact> with get, set
        abstract resources: ResizeArray<ResourceRole> with get, set
        abstract correlationSubscriptions: ResizeArray<CorrelationSubscription> with get, set
        abstract supports: ResizeArray<Process> with get, set
        abstract definitionalCollaborationRef: Collaboration with get, set
        abstract isExecutable: bool with get, set

    type [<AllowNullLiteral>] LaneSet =
        inherit BaseElement
        abstract lanes: ResizeArray<Lane> with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] Lane =
        inherit BaseElement
        abstract name: string with get, set
        abstract partitionElementRef: BaseElement with get, set
        abstract partitionElement: BaseElement with get, set
        abstract flowNodeRef: ResizeArray<FlowNode> with get, set
        abstract childLaneSet: LaneSet with get, set

    type [<AllowNullLiteral>] GlobalManualTask =
        inherit GlobalTask

    type [<AllowNullLiteral>] ManualTask =
        inherit Task

    type [<AllowNullLiteral>] UserTask =
        inherit Task
        abstract renderings: ResizeArray<Rendering> with get, set
        abstract implementation: string with get, set

    type [<AllowNullLiteral>] Rendering =
        inherit BaseElement

    type [<AllowNullLiteral>] HumanPerformer =
        inherit Performer

    type [<AllowNullLiteral>] PotentialOwner =
        inherit Performer

    type [<AllowNullLiteral>] GlobalUserTask =
        inherit GlobalTask
        abstract implementation: string with get, set
        abstract renderings: Rendering with get, set

    type [<AllowNullLiteral>] Gateway =
        inherit FlowNode
        abstract gatewayDirection: GatewayDirection with get, set

    type [<AllowNullLiteral>] EventBasedGateway =
        inherit Gateway
        abstract instantiate: bool with get, set
        abstract eventGatewayType: EventBasedGatewayType with get, set

    type [<AllowNullLiteral>] ComplexGateway =
        inherit Gateway
        abstract activationCondition: Expression with get, set
        abstract ``default``: SequenceFlow with get, set

    type [<AllowNullLiteral>] ExclusiveGateway =
        inherit Gateway
        abstract ``default``: SequenceFlow with get, set

    type [<AllowNullLiteral>] InclusiveGateway =
        inherit Gateway
        abstract ``default``: SequenceFlow with get, set

    type [<AllowNullLiteral>] ParallelGateway =
        inherit Gateway

    type [<AllowNullLiteral>] Relationship =
        inherit BaseElement
        abstract ``type``: string with get, set
        abstract direction: RelationshipDirection with get, set
        abstract source: ResizeArray<BaseElement> with get, set
        abstract target: ResizeArray<BaseElement> with get, set

    type [<AllowNullLiteral>] Extension =
        inherit TypeDerived
        abstract mustUnderstand: bool with get, set
        abstract definition: ExtensionDefinition with get, set

    type [<AllowNullLiteral>] ExtensionDefinition =
        inherit TypeDerived
        abstract name: string with get, set
        abstract extensionAttributeDefinitions: ResizeArray<ExtensionAttributeDefinition> with get, set

    type [<AllowNullLiteral>] ExtensionAttributeDefinition =
        inherit TypeDerived
        abstract name: string with get, set
        abstract ``type``: string with get, set
        abstract isReference: bool with get, set

    type [<AllowNullLiteral>] ExtensionElements =
        inherit TypeDerived
        abstract valueRef: BaseElement with get, set
        abstract values: ResizeArray<BaseElement> with get, set
        abstract extensionAttributeDefinition: ExtensionAttributeDefinition with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] Documentation =
        inherit BaseElement
        abstract text: string with get, set
        abstract textFormat: string with get, set

    type [<AllowNullLiteral>] Event =
        inherit FlowNode
        inherit InteractionNode
        abstract properties: ResizeArray<Property> with get, set

    type [<AllowNullLiteral>] IntermediateCatchEvent =
        inherit CatchEvent

    type [<AllowNullLiteral>] IntermediateThrowEvent =
        inherit ThrowEvent

    type [<AllowNullLiteral>] EndEvent =
        inherit ThrowEvent

    type [<AllowNullLiteral>] StartEvent =
        inherit CatchEvent
        abstract isInterrupting: bool with get, set

    type [<AllowNullLiteral>] ThrowEvent =
        inherit Event
        abstract dataInputs: ResizeArray<DataInput> with get, set
        abstract dataInputAssociations: ResizeArray<DataInputAssociation> with get, set
        abstract inputSet: InputSet with get, set
        abstract eventDefinitions: ResizeArray<EventDefinition> with get, set
        abstract eventDefinitionRef: ResizeArray<EventDefinition> with get, set

    type [<AllowNullLiteral>] CatchEvent =
        inherit Event
        abstract parallelMultiple: bool with get, set
        abstract dataOutputs: ResizeArray<DataOutput> with get, set
        abstract dataOutputAssociations: ResizeArray<DataOutputAssociation> with get, set
        abstract outputSet: OutputSet with get, set
        abstract eventDefinitions: ResizeArray<EventDefinition> with get, set

    type [<AllowNullLiteral>] BoundaryEvent =
        inherit CatchEvent
        abstract cancelActivity: bool with get, set
        abstract attachedToRef: Activity with get, set

    type [<AllowNullLiteral>] EventDefinition =
        inherit RootElement

    type [<AllowNullLiteral>] CancelEventDefinition =
        inherit EventDefinition

    type [<AllowNullLiteral>] ErrorEventDefinition =
        inherit EventDefinition
        abstract errorRef: ErrorElement with get, set

    type [<AllowNullLiteral>] TerminateEventDefinition =
        inherit EventDefinition

    type [<AllowNullLiteral>] EscalationEventDefinition =
        inherit EventDefinition
        abstract escalationRef: Escalation with get, set

    type [<AllowNullLiteral>] Escalation =
        inherit RootElement
        abstract structureRef: ItemDefinition with get, set
        abstract name: string with get, set
        abstract escalationCode: string with get, set

    type [<AllowNullLiteral>] CompensateEventDefinition =
        inherit EventDefinition
        abstract waitForCompletion: bool with get, set
        abstract activityRef: Activity with get, set

    type [<AllowNullLiteral>] TimerEventDefinition =
        inherit EventDefinition
        abstract timeDate: Expression with get, set
        abstract timeCycle: Expression with get, set
        abstract timeDuration: Expression with get, set

    type [<AllowNullLiteral>] LinkEventDefinition =
        inherit EventDefinition
        abstract name: string with get, set
        abstract target: LinkEventDefinition with get, set
        abstract source: LinkEventDefinition with get, set

    type [<AllowNullLiteral>] MessageEventDefinition =
        inherit EventDefinition
        abstract nessageRef: Message with get, set
        abstract operationRef: Operation with get, set

    type [<AllowNullLiteral>] ConditionalEventDefinition =
        inherit EventDefinition
        abstract condition: Expression with get, set

    type [<AllowNullLiteral>] SignalEventDefinition =
        inherit EventDefinition
        abstract singalRef: Signal with get, set

    type [<AllowNullLiteral>] Signal =
        inherit RootElement
        abstract structureRef: ItemDefinition with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] ImplicitThrowEvent =
        inherit ThrowEvent

    type [<AllowNullLiteral>] DataState =
        inherit BaseElement
        abstract name: string with get, set

    type [<AllowNullLiteral>] ItemAwareElement =
        inherit BaseElement
        abstract itemSubjectRef: ItemDefinition with get, set
        abstract dataState: DataState with get, set

    type [<AllowNullLiteral>] DataAssociation =
        inherit BaseElement
        abstract assignment: Assignment with get, set
        abstract sourceRef: ItemAwareElement with get, set
        abstract targetRef: ItemAwareElement with get, set
        abstract transformation: FormalExpression with get, set

    type [<AllowNullLiteral>] DataInput =
        inherit ItemAwareElement
        abstract name: string with get, set
        abstract isCollection: bool with get, set
        abstract inputSetRef: InputSet with get, set
        abstract inputSetWithOptional: InputSet with get, set
        abstract inputSetWithWhileExecuting: InputSet with get, set

    type [<AllowNullLiteral>] DataOutput =
        inherit ItemAwareElement
        abstract name: string with get, set
        abstract isCollection: bool with get, set
        abstract outputSetRef: ResizeArray<InputSet> with get, set
        abstract outputSetWithOptional: ResizeArray<InputSet> with get, set
        abstract outputSetWithWhileExecuting: ResizeArray<InputSet> with get, set

    type [<AllowNullLiteral>] InputSet =
        inherit BaseElement
        abstract name: string with get, set
        abstract dataInputRefs: ResizeArray<DataInput> with get, set
        abstract optionalInputRefs: ResizeArray<DataInput> with get, set
        abstract whileExecutingInputsRefs: ResizeArray<DataInput> with get, set
        abstract outputSetRefs: ResizeArray<OutputSet> with get, set

    type [<AllowNullLiteral>] OutputSet =
        inherit BaseElement
        abstract dataOutputRefs: ResizeArray<DataOutput> with get, set
        abstract name: string with get, set
        abstract inputSetRefs: ResizeArray<InputSet> with get, set
        abstract optionalOutputRefs: ResizeArray<DataOutput> with get, set
        abstract whileExecutingOutputREfs: ResizeArray<DataOutput> with get, set

    type [<AllowNullLiteral>] Property =
        inherit ItemAwareElement
        abstract name: string with get, set

    type [<AllowNullLiteral>] DataInputAssociation =
        inherit DataAssociation

    type [<AllowNullLiteral>] DataOutputAssociation =
        inherit DataAssociation

    type [<AllowNullLiteral>] InputOutputSpecification =
        inherit BaseElement
        abstract dataInputs: ResizeArray<DataInput> with get, set
        abstract dataOutputs: ResizeArray<DataOutput> with get, set
        abstract inputSets: ResizeArray<InputSet> with get, set
        abstract outputSets: ResizeArray<OutputSet> with get, set

    type [<AllowNullLiteral>] DataObject =
        inherit FlowElement
        inherit ItemAwareElement
        abstract isCollection: bool with get, set

    type [<AllowNullLiteral>] InputOutputBinding =
        inherit TypeDerived
        abstract inputDataRef: InputSet with get, set
        abstract outputDataRef: OutputSet with get, set
        abstract operationRef: Operation with get, set

    type [<AllowNullLiteral>] Assignment =
        inherit BaseElement
        abstract from: Expression with get, set
        abstract ``to``: Expression with get, set

    type [<AllowNullLiteral>] DataStore =
        inherit RootElement
        inherit ItemAwareElement
        abstract name: string with get, set
        abstract capacity: float with get, set
        abstract isUnlimited: bool with get, set

    type [<AllowNullLiteral>] DataStoreReference =
        inherit FlowElement
        inherit ItemAwareElement
        abstract dataStoreRef: DataStore with get, set

    type [<AllowNullLiteral>] DataObjectReference =
        inherit ItemAwareElement
        inherit FlowElement
        abstract dataObjectRef: DataObject with get, set

    type [<AllowNullLiteral>] ConversationLink =
        inherit BaseElement
        abstract sourceRef: InteractionNode with get, set
        abstract targetRef: InteractionNode with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] ConversationAssociation =
        inherit ConversationNode
        abstract innerConversationNodeRef: ConversationNode with get, set
        abstract outerConversationNodeRef: ConversationNode with get, set

    type [<AllowNullLiteral>] CallConversation =
        inherit ConversationNode
        abstract calledCollaborationRef: Collaboration with get, set
        abstract participantAssociations: ResizeArray<ParticipantAssociation> with get, set

    type [<AllowNullLiteral>] Conversation =
        inherit ConversationNode

    type [<AllowNullLiteral>] SubConversation =
        inherit ConversationNode
        abstract conversationNodes: ResizeArray<ConversationNode> with get, set

    type [<AllowNullLiteral>] ConversationNode =
        inherit InteractionNode
        inherit BaseElement
        abstract name: string with get, set
        abstract participantRefs: ResizeArray<Participant> with get, set
        abstract messageFlowRefs: ResizeArray<MessageFlow> with get, set
        abstract correlationKeys: ResizeArray<CorrelationKey> with get, set

    type [<AllowNullLiteral>] GlobalConversation =
        inherit Collaboration

    type [<AllowNullLiteral>] PartnerEntity =
        inherit RootElement
        abstract name: string with get, set
        abstract participantRef: ResizeArray<Participant> with get, set

    type [<AllowNullLiteral>] PartnerRole =
        inherit RootElement
        abstract name: string with get, set
        abstract participantRef: ResizeArray<Participant> with get, set

    type [<AllowNullLiteral>] CorrelationProperty =
        inherit RootElement
        abstract correlationPropertyRetrievalExpression: CorrelationPropertyRetrievalExpression with get, set
        abstract name: string with get, set
        abstract ``type``: ItemDefinition with get, set

    type [<AllowNullLiteral>] ErrorElement =
        inherit RootElement
        abstract structureRef: ItemDefinition with get, set
        abstract name: string with get, set
        abstract errorCode: string with get, set

    type [<AllowNullLiteral>] CorrelationKey =
        inherit BaseElement
        abstract correlationPropertyRef: CorrelationProperty with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] Expression =
        inherit BaseElement
        abstract body: string with get, set

    type [<AllowNullLiteral>] FormalExpression =
        inherit Expression
        abstract language: string with get, set
        abstract evaluatesToTypeRef: ItemDefinition with get, set

    type [<AllowNullLiteral>] Message =
        inherit RootElement
        abstract name: string with get, set
        abstract itemRef: ItemDefinition with get, set

    type [<AllowNullLiteral>] ItemDefinition =
        inherit RootElement
        abstract itemKind: ItemKind with get, set
        abstract structureRef: string with get, set
        abstract isCollection: bool with get, set
        abstract import: Import with get, set

    type [<AllowNullLiteral>] FlowElement =
        inherit RootElement
        abstract name: string option with get, set
        abstract auditing: Auditing with get, set
        abstract monitoring: Monitoring with get, set
        abstract categoryValueRef: ResizeArray<CategoryValue> with get, set

    type [<AllowNullLiteral>] SequenceFlow =
        inherit FlowElement
        abstract isImmediate: bool with get, set
        abstract conditionExpression: Expression with get, set
        abstract sourceRef: FlowNode with get, set
        abstract targetRef: FlowNode with get, set

    type [<AllowNullLiteral>] FlowElementsContainer =
        inherit BaseElement
        abstract laneSets: ResizeArray<LaneSet> with get, set
        abstract flowElements: ResizeArray<FlowElement> with get, set

    type [<AllowNullLiteral>] FlowNode =
        inherit FlowElement
        abstract incoming: ResizeArray<SequenceFlow> with get, set
        abstract outgoing: ResizeArray<SequenceFlow> with get, set
        abstract lanes: ResizeArray<Lane> with get, set

    type [<AllowNullLiteral>] CorrelationPropertyRetrievalExpression =
        inherit BaseElement
        abstract messagePath: FormalExpression with get, set
        abstract messageRef: Message with get, set

    type [<AllowNullLiteral>] CorrelationPropertyBinding =
        inherit BaseElement
        abstract dataPath: FormalExpression with get, set
        abstract correlationPropertyRef: CorrelationProperty with get, set

    type [<AllowNullLiteral>] Resource =
        inherit RootElement
        abstract name: string with get, set
        abstract resourceParameters: ResizeArray<ResourceParameter> with get, set

    type [<AllowNullLiteral>] ResourceParameter =
        inherit BaseElement
        abstract name: string with get, set
        abstract isRequired: bool with get, set
        abstract ``type``: ItemDefinition with get, set

    type [<AllowNullLiteral>] CorrelationSubscription =
        inherit BaseElement
        abstract correlationKeyRef: CorrelationKey with get, set
        abstract correlationPropertyBinding: ResizeArray<CorrelationKey> with get, set

    type [<AllowNullLiteral>] MessageFlow =
        inherit BaseElement
        abstract name: string with get, set
        abstract sourceRef: InteractionNode with get, set
        abstract targetRef: InteractionNode with get, set
        abstract messageRef: Message with get, set

    type [<AllowNullLiteral>] MessageFlowAssociation =
        inherit BaseElement
        abstract innerMessageFlowRef: MessageFlow with get, set
        abstract outerMessageFlowRef: MessageFlow with get, set

    type [<AllowNullLiteral>] InteractionNode =
        inherit TypeDerived
        abstract incomingConversationLinks: ResizeArray<ConversationLink> with get, set
        abstract outgoingConversationLinks: ResizeArray<ConversationLink> with get, set

    type [<AllowNullLiteral>] Participant =
        inherit InteractionNode
        inherit BaseElement
        abstract name: string with get, set
        abstract interfaceRef: ResizeArray<Interface> with get, set
        abstract participantMultiplicity: ParticipantMultiplicity with get, set
        abstract endPointRefs: ResizeArray<EndPoint> with get, set
        abstract processRef: Process with get, set

    type [<AllowNullLiteral>] ParticipantAssociation =
        inherit BaseElement
        abstract innerParticipantRef: Participant with get, set
        abstract outerParticipantRef: Participant with get, set

    type [<AllowNullLiteral>] ParticipantMultiplicity =
        inherit BaseElement
        abstract minimum: float with get, set
        abstract maximum: float with get, set

    type [<AllowNullLiteral>] Collaboration =
        inherit RootElement
        abstract name: string with get, set
        abstract isClosed: bool with get, set
        abstract participants: ResizeArray<Participant> with get, set
        abstract messageFlows: ResizeArray<MessageFlow> with get, set
        abstract artifacts: ResizeArray<Artifact> with get, set
        abstract conversations: ResizeArray<ConversationNode> with get, set
        abstract conversationAssociations: ResizeArray<ConversationAssociation> with get, set
        abstract participantAssociations: ResizeArray<ParticipantAssociation> with get, set
        abstract messageFlowAssociations: ResizeArray<MessageFlowAssociation> with get, set
        abstract correlationKeys: ResizeArray<CorrelationKey> with get, set
        abstract choreographyRef: ResizeArray<Choreography> with get, set
        abstract conversationLinks: ResizeArray<ConversationLink> with get, set

    type [<AllowNullLiteral>] ChoreographyActivity =
        inherit FlowNode
        abstract participantRef: ResizeArray<Participant> with get, set
        abstract initiatingParticipantRef: Participant with get, set
        abstract correlationKeys: ResizeArray<CorrelationKey> with get, set
        abstract loopType: ChoreographyLoopType with get, set

    type [<AllowNullLiteral>] CallChoreography =
        inherit ChoreographyActivity
        abstract calledChoreographyRef: Choreography with get, set
        abstract participantAssociations: ResizeArray<ParticipantAssociation> with get, set

    type [<AllowNullLiteral>] SubChoreography =
        inherit ChoreographyActivity
        inherit FlowElementsContainer
        abstract artifacts: ResizeArray<Artifact> with get, set

    type [<AllowNullLiteral>] ChoreographyTask =
        inherit ChoreographyActivity
        abstract messageFlowRef: ResizeArray<MessageFlow> with get, set

    type [<AllowNullLiteral>] Choreography =
        inherit FlowElementsContainer
        inherit Collaboration

    type [<AllowNullLiteral>] GlobalChoreographyTask =
        inherit Choreography
        abstract initiatingParticipantRef: Participant with get, set

    type [<AllowNullLiteral>] TextAnnotation =
        inherit Artifact
        abstract text: string with get, set
        abstract textFormat: string with get, set

    type [<AllowNullLiteral>] Group =
        inherit Artifact
        abstract categoryValueRef: CategoryValue with get, set

    type [<AllowNullLiteral>] Association =
        inherit Artifact
        abstract associationDirection: AssociationDirection with get, set
        abstract sourceRef: BaseElement with get, set
        abstract targetRef: BaseElement with get, set

    type [<AllowNullLiteral>] Category =
        inherit RootElement
        abstract categoryValue: CategoryValue with get, set
        abstract name: string with get, set

    type [<AllowNullLiteral>] Artifact =
        inherit BaseElement

    type [<AllowNullLiteral>] CategoryValue =
        inherit BaseElement
        abstract categorizedFlowElements: ResizeArray<FlowElement> with get, set
        abstract value: string with get, set

    type [<AllowNullLiteral>] Activity =
        inherit FlowNode
        abstract isForCompensation: bool with get, set
        abstract ``default``: SequenceFlow with get, set
        abstract ioSpecification: InputOutputSpecification with get, set
        abstract boundaryEventRefs: ResizeArray<BoundaryEvent> with get, set
        abstract properties: ResizeArray<Property> with get, set
        abstract dataInputAssociations: ResizeArray<DataInputAssociation> with get, set
        abstract dataOutputAssociations: ResizeArray<DataOutputAssociation> with get, set
        abstract startQuantity: float with get, set
        abstract resources: ResourceRole with get, set
        abstract completionQuantity: float with get, set
        abstract loopCharacteristics: LoopCharacteristics with get, set

    type [<AllowNullLiteral>] ServiceTask =
        inherit Task
        abstract implementation: string with get, set
        abstract operationRef: Operation with get, set

    type [<AllowNullLiteral>] SubProcess =
        inherit Activity
        inherit FlowElementsContainer
        inherit InteractionNode
        abstract triggeredByEvent: bool with get, set
        abstract artifacts: ResizeArray<Artifact> with get, set

    type [<AllowNullLiteral>] LoopCharacteristics =
        inherit BaseElement

    type [<AllowNullLiteral>] MultiInstanceLoopCharacteristics =
        inherit LoopCharacteristics
        abstract isSequential: bool with get, set
        abstract behavior: MultiInstanceBehaviour with get, set
        abstract loopCardinality: Expression with get, set
        abstract loopDataInputRef: ItemAwareElement with get, set
        abstract loopDataOutputRef: ItemAwareElement with get, set
        abstract inputDataItem: DataInput with get, set
        abstract outputDataItem: DataOutput with get, set
        abstract complexBehaviorDefinition: ComplexBehaviorDefinition with get, set
        abstract completionCondition: Expression with get, set
        abstract oneBehaviorEventRef: EventDefinition with get, set
        abstract noneBehaviorEventRef: EventDefinition with get, set

    type [<AllowNullLiteral>] StandardLoopCharacteristics =
        inherit LoopCharacteristics
        abstract testBefore: bool with get, set
        abstract loopCondition: Expression with get, set
        abstract loopMaximum: Expression with get, set

    type [<AllowNullLiteral>] CallActivity =
        inherit Activity
        abstract calledElement: string with get, set

    type [<AllowNullLiteral>] Task =
        inherit Activity
        inherit InteractionNode

    type [<AllowNullLiteral>] SendTask =
        inherit Task
        abstract implementation: string with get, set
        abstract operationRef: Operation with get, set
        abstract messageRef: Message with get, set

    type [<AllowNullLiteral>] ReceiveTask =
        inherit Task
        abstract implementation: string with get, set
        abstract instantiate: bool with get, set
        abstract operationRef: Operation with get, set
        abstract messageRef: Message with get, set

    type [<AllowNullLiteral>] ScriptTask =
        inherit Task
        abstract scriptFormat: string with get, set
        abstract script: string with get, set

    type [<AllowNullLiteral>] BusinessRuleTask =
        inherit Task
        abstract implementation: string with get, set

    type [<AllowNullLiteral>] AdHocSubProcess =
        inherit SubProcess
        abstract completionCondition: Expression with get, set
        abstract ordering: AdHocOrdering with get, set
        abstract cancelRemainingInstances: bool with get, set

    type [<AllowNullLiteral>] Transaction =
        inherit SubProcess
        abstract protocal: string with get, set
        abstract ``method``: string with get, set

    type [<AllowNullLiteral>] GlobalScriptTask =
        inherit GlobalTask
        abstract scriptLanguage: string with get, set
        abstract script: string with get, set

    type [<AllowNullLiteral>] GlobalBusinessRuleTask =
        inherit GlobalTask
        abstract implementation: string with get, set

    type [<AllowNullLiteral>] ComplexBehaviorDefinition =
        inherit BaseElement
        abstract condition: FormalExpression with get, set
        abstract ``event``: ImplicitThrowEvent with get, set

    type [<AllowNullLiteral>] ResourceParameterBinding =
        inherit TypeDerived
        abstract expression: Expression with get, set
        abstract parameterRef: ResourceParameter with get, set

    type [<AllowNullLiteral>] ResourceAssignmentExpression =
        inherit BaseElement
        abstract expression: Expression with get, set

    type [<AllowNullLiteral>] Import =
        inherit TypeDerived
        abstract importType: string with get, set
        abstract location: string with get, set
        abstract ``namespace``: string with get, set

    type [<AllowNullLiteral>] Definitions =
        inherit BaseElement
        abstract name: string with get, set
        abstract targetNamespace: string with get, set
        abstract expressionLanguage: string with get, set
        abstract typeLanguage: string with get, set
        abstract imports: ResizeArray<Import> with get, set
        abstract extensions: ResizeArray<Extension> with get, set
        abstract rootElements: ResizeArray<RootElement> with get, set
        abstract diagrams: BPMNDiagram with get, set
        abstract er: string with get, set
        abstract relationship: ResizeArray<Relationship> with get, set
        abstract erVersion: string with get, set

    type [<AllowNullLiteral>] BPMNDiagram =
        inherit Diagram
        abstract plane: BPMNPlane with get, set
        abstract labelStyle: BPMNLabelStyle with get, set

    type [<AllowNullLiteral>] BPMNPlane =
        inherit Plane

    type [<AllowNullLiteral>] BPMNShape =
        inherit LabeledShape

    type [<AllowNullLiteral>] BPMNEdge =
        inherit LabeledEdge

    type [<AllowNullLiteral>] BPMNLabel =
        inherit Label

    type [<AllowNullLiteral>] BPMNLabelStyle =
        inherit Style

    type [<AllowNullLiteral>] Font =
        inherit TypeDerived
        abstract name: string with get, set
        abstract size: float with get, set
        abstract isBold: bool with get, set
        abstract isItalic: bool with get, set
        abstract isUnderline: bool with get, set
        abstract isStrikeThrough: bool with get, set

    type [<AllowNullLiteral>] Point =
        inherit TypeDerived
        abstract x: float with get, set
        abstract y: float with get, set
        abstract width: float with get, set
        abstract height: float with get, set

    type [<AllowNullLiteral>] Bounds =
        inherit TypeDerived

    type [<AllowNullLiteral>] DiagramElement =
        inherit TypeDerived

    type [<AllowNullLiteral>] Node =
        inherit TypeDerived

    type [<AllowNullLiteral>] Edge =
        inherit TypeDerived

    type [<AllowNullLiteral>] Diagram =
        inherit TypeDerived

    type [<AllowNullLiteral>] Shape =
        inherit TypeDerived

    type [<AllowNullLiteral>] Plane =
        inherit TypeDerived

    type [<AllowNullLiteral>] LabeledEdge =
        inherit TypeDerived

    type [<AllowNullLiteral>] LabeledShape =
        inherit TypeDerived

    type [<AllowNullLiteral>] Label =
        inherit TypeDerived

    type [<AllowNullLiteral>] Style =
        inherit TypeDerived

    type [<AllowNullLiteral>] ColoredShape =
        inherit TypeDerived

    type [<AllowNullLiteral>] ColoredEdge =
        inherit TypeDerived

    type [<AllowNullLiteral>] ElementTypes =
        abstract bpmn_Interface: Interface with get, set
        abstract bpmn_Operation: Operation with get, set
        abstract bpmn_EndPoint: EndPoint with get, set
        abstract bpmn_Auditing: Auditing with get, set
        abstract bpmn_GlobalTask: GlobalTask with get, set
        abstract bpmn_Monitoring: Monitoring with get, set
        abstract bpmn_Performer: Performer with get, set
        abstract bpmn_Process: Process with get, set
        abstract bpmn_LaneSet: LaneSet with get, set
        abstract bpmn_Lane: Lane with get, set
        abstract bpmn_GlobalManualTask: GlobalManualTask with get, set
        abstract bpmn_ManualTask: ManualTask with get, set
        abstract bpmn_UserTask: UserTask with get, set
        abstract bpmn_Rendering: Rendering with get, set
        abstract bpmn_HumanPerformer: HumanPerformer with get, set
        abstract bpmn_PotentialOwner: PotentialOwner with get, set
        abstract bpmn_GlobalUserTask: GlobalUserTask with get, set
        abstract bpmn_Gateway: Gateway with get, set
        abstract bpmn_EventBasedGateway: EventBasedGateway with get, set
        abstract bpmn_ComplexGateway: ComplexGateway with get, set
        abstract bpmn_ExclusiveGateway: ExclusiveGateway with get, set
        abstract bpmn_InclusiveGateway: InclusiveGateway with get, set
        abstract bpmn_ParallelGateway: ParallelGateway with get, set
        abstract bpmn_RootElement: RootElement with get, set
        abstract bpmn_Relationship: Relationship with get, set
        abstract bpmn_BaseElement: BaseElement with get, set
        abstract bpmn_Extension: Extension with get, set
        abstract bpmn_ExtensionDefinition: ExtensionDefinition with get, set
        abstract bpmn_ExtensionAttributeDefinition: ExtensionAttributeDefinition with get, set
        abstract bpmn:ExtensionElements: ExtensionElements with get, set
        abstract bpmn:Documentation: Documentation with get, set
        abstract bpmn:Event: Event with get, set
        abstract bpmn:IntermediateCatchEvent: IntermediateCatchEvent with get, set
        abstract bpmn:IntermediateThrowEvent: IntermediateThrowEvent with get, set
        abstract bpmn:EndEvent: EndEvent with get, set
        abstract bpmn:StartEvent: StartEvent with get, set
        abstract bpmn:ThrowEvent: ThrowEvent with get, set
        abstract bpmn:CatchEvent: CatchEvent with get, set
        abstract bpmn:BoundaryEvent: BoundaryEvent with get, set
        abstract bpmn:EventDefinition: EventDefinition with get, set
        abstract bpmn:CancelEventDefinition: CancelEventDefinition with get, set
        abstract bpmn:ErrorEventDefinition: ErrorEventDefinition with get, set
        abstract bpmn:TerminateEventDefinition: TerminateEventDefinition with get, set
        abstract bpmn:EscalationEventDefinition: EscalationEventDefinition with get, set
        abstract bpmn:Escalation: Escalation with get, set
        abstract bpmn:CompensateEventDefinition: CompensateEventDefinition with get, set
        abstract bpmn:TimerEventDefinition: TimerEventDefinition with get, set
        abstract bpmn:LinkEventDefinition: LinkEventDefinition with get, set
        abstract bpmn:MessageEventDefinition: MessageEventDefinition with get, set
        abstract bpmn:ConditionalEventDefinition: ConditionalEventDefinition with get, set
        abstract bpmn:SignalEventDefinition: SignalEventDefinition with get, set
        abstract bpmn:Signal: Signal with get, set
        abstract bpmn:ImplicitThrowEvent: ImplicitThrowEvent with get, set
        abstract bpmn:DataState: DataState with get, set
        abstract bpmn:ItemAwareElement: ItemAwareElement with get, set
        abstract bpmn:DataAssociation: DataAssociation with get, set
        abstract bpmn:DataInput: DataInput with get, set
        abstract bpmn:DataOutput: DataOutput with get, set
        abstract bpmn:InputSet: InputSet with get, set
        abstract bpmn:OutputSet: OutputSet with get, set
        abstract bpmn:Property: Property with get, set
        abstract bpmn:DataInputAssociation: DataInputAssociation with get, set
        abstract bpmn:DataOutputAssociation: DataOutputAssociation with get, set
        abstract bpmn:InputOutputSpecification: InputOutputSpecification with get, set
        abstract bpmn:DataObject: DataObject with get, set
        abstract bpmn:InputOutputBinding: InputOutputBinding with get, set
        abstract bpmn:Assignment: Assignment with get, set
        abstract bpmn:DataStore: DataStore with get, set
        abstract bpmn:DataStoreReference: DataStoreReference with get, set
        abstract bpmn:DataObjectReference: DataObjectReference with get, set
        abstract bpmn:ConversationLink: ConversationLink with get, set
        abstract bpmn:ConversationAssociation: ConversationAssociation with get, set
        abstract bpmn:CallConversation: CallConversation with get, set
        abstract bpmn:Conversation: Conversation with get, set
        abstract bpmn:SubConversation: SubConversation with get, set
        abstract bpmn:ConversationNode: ConversationNode with get, set
        abstract bpmn:GlobalConversation: GlobalConversation with get, set
        abstract bpmn:PartnerEntity: PartnerEntity with get, set
        abstract bpmn:PartnerRole: PartnerRole with get, set
        abstract bpmn:CorrelationProperty: CorrelationProperty with get, set
        abstract bpmn:Error: ErrorElement with get, set
        abstract bpmn:CorrelationKey: CorrelationKey with get, set
        abstract bpmn:Expression: Expression with get, set
        abstract bpmn:FormalExpression: FormalExpression with get, set
        abstract bpmn:Message: Message with get, set
        abstract bpmn:ItemDefinition: ItemDefinition with get, set
        abstract bpmn:FlowElement: FlowElement with get, set
        abstract bpmn:SequenceFlow: SequenceFlow with get, set
        abstract bpmn:FlowElementsContainer: FlowElementsContainer with get, set
        abstract bpmn:CallableElement: CallableElement with get, set
        abstract bpmn:FlowNode: FlowNode with get, set
        abstract bpmn:CorrelationPropertyRetrievalExpression: CorrelationPropertyRetrievalExpression with get, set
        abstract bpmn:CorrelationPropertyBinding: CorrelationPropertyBinding with get, set
        abstract bpmn:Resource: Resource with get, set
        abstract bpmn:ResourceParameter: ResourceParameter with get, set
        abstract bpmn:CorrelationSubscription: CorrelationSubscription with get, set
        abstract bpmn:MessageFlow: MessageFlow with get, set
        abstract bpmn:MessageFlowAssociation: MessageFlowAssociation with get, set
        abstract bpmn:InteractionNode: InteractionNode with get, set
        abstract bpmn:Participant: Participant with get, set
        abstract bpmn:ParticipantAssociation: ParticipantAssociation with get, set
        abstract bpmn:ParticipantMultiplicity: ParticipantMultiplicity with get, set
        abstract bpmn:Collaboration: Collaboration with get, set
        abstract bpmn:ChoreographyActivity: ChoreographyActivity with get, set
        abstract bpmn:CallChoreography: CallChoreography with get, set
        abstract bpmn:SubChoreography: SubChoreography with get, set
        abstract bpmn:ChoreographyTask: ChoreographyTask with get, set
        abstract bpmn:Choreography: Choreography with get, set
        abstract bpmn:GlobalChoreographyTask: GlobalChoreographyTask with get, set
        abstract bpmn:TextAnnotation: TextAnnotation with get, set
        abstract bpmn:Group: Group with get, set
        abstract bpmn:Association: Association with get, set
        abstract bpmn:Category: Category with get, set
        abstract bpmn:Artifact: Artifact with get, set
        abstract bpmn:CategoryValue: CategoryValue with get, set
        abstract bpmn:Activity: Activity with get, set
        abstract bpmn:ServiceTask: ServiceTask with get, set
        abstract bpmn:SubProcess: SubProcess with get, set
        abstract bpmn:LoopCharacteristics: LoopCharacteristics with get, set
        abstract bpmn:MultiInstanceLoopCharacteristics: MultiInstanceLoopCharacteristics with get, set
        abstract bpmn:StandardLoopCharacteristics: StandardLoopCharacteristics with get, set
        abstract bpmn:CallActivity: CallActivity with get, set
        abstract bpmn:Task: Task with get, set
        abstract bpmn:SendTask: SendTask with get, set
        abstract bpmn:ReceiveTask: ReceiveTask with get, set
        abstract bpmn:ScriptTask: ScriptTask with get, set
        abstract bpmn:BusinessRuleTask: BusinessRuleTask with get, set
        abstract bpmn:AdHocSubProcess: AdHocSubProcess with get, set
        abstract bpmn:Transaction: Transaction with get, set
        abstract bpmn:GlobalScriptTask: GlobalScriptTask with get, set
        abstract bpmn:GlobalBusinessRuleTask: GlobalBusinessRuleTask with get, set
        abstract bpmn:ComplexBehaviorDefinition: ComplexBehaviorDefinition with get, set
        abstract bpmn:ResourceRole: ResourceRole with get, set
        abstract bpmn:ResourceParameterBinding: ResourceParameterBinding with get, set
        abstract bpmn:ResourceAssignmentExpression: ResourceAssignmentExpression with get, set
        abstract bpmn:Import: Import with get, set
        abstract bpmn:Definitions: Definitions with get, set
        abstract bpmndi:BPMNDiagram: BPMNDiagram with get, set
        abstract bpmndi:BPMNPlane: BPMNPlane with get, set
        abstract bpmndi:BPMNShape: BPMNShape with get, set
        abstract bpmndi:BPMNEdge: BPMNEdge with get, set
        abstract bpmndi:BPMNLabel: BPMNLabel with get, set
        abstract bpmndi:BPMNLabelStyle: BPMNLabelStyle with get, set
        abstract dc:boolean: bool with get, set
        abstract dc:number: float with get, set
        abstract dc:Real: obj option with get, set
        abstract dc:string: string with get, set
        abstract dc:Font: Font with get, set
        abstract dc:Point: Point with get, set
        abstract dc:Bounds: Bounds with get, set
        abstract di:DiagramElement: DiagramElement with get, set
        abstract di:Node: Node with get, set
        abstract di:Edge: Edge with get, set
        abstract di:Diagram: Diagram with get, set
        abstract di:Shape: Shape with get, set
        abstract di:Plane: Plane with get, set
        abstract di:LabeledEdge: LabeledEdge with get, set
        abstract di:LabeledShape: LabeledShape with get, set
        abstract di:Label: Label with get, set
        abstract di:Style: Style with get, set
        abstract di:Extension: Extension with get, set
        abstract bioc:ColoredShape: ColoredShape with get, set
        abstract bioc:ColoredEdge: ColoredEdge with get, set

    type ElementType =
        obj

    type [<AllowNullLiteral>] Option =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] BPMNModdleConstructor =
        interface end

    type [<AllowNullLiteral>] BPMNModdleConstructorStatic =
        [<Emit "new $0($1...)">] abstract Create: ?packages: obj * ?options: Option -> BPMNModdleConstructor

    type [<AllowNullLiteral>] ImportFn =
        [<Emit "$0($1...)">] abstract Invoke: err: Error * definitions: Definitions * parseContext: obj option -> unit

    type [<AllowNullLiteral>] Moddle =
        /// <summary>Create an instance of the specified type.</summary>
        /// <param name="descriptor">the type descriptor or name know to the model</param>
        /// <param name="attrs">a number of attributes to initialize the model instance with</param>
        abstract create: descriptor: 'K * ?attrs: obj -> 'T
        abstract create: descriptor: obj option * ?attrs: obj -> BaseElement
        /// <summary>Returns the type representing a given descriptor</summary>
        /// <param name="descriptor">the type descriptor or name know to the model</param>
        abstract getType: descriptor: obj option -> obj option
        /// <summary>Creates an any-element type to be used within model instances.
        /// 
        /// This can be used to create custom elements that lie outside the meta-model.
        /// The created element contains all the meta-data required to serialize it
        /// as part of meta-model elements.</summary>
        /// <param name="name">the name of the element</param>
        /// <param name="nsUri">the namespace uri of the element</param>
        /// <param name="properties">a map of properties to initialize the instance with</param>
        abstract createAny: name: string * nsUri: string * properties: obj option -> obj option
        /// Returns a registered package by uri or prefix
        abstract getPackage: uriOrPrefix: obj option -> obj option
        /// Returns a snapshot of all known packages
        abstract getPackages: unit -> obj option
        /// Returns the descriptor for an element
        abstract getElementDescriptor: element: obj option -> obj option
        /// Returns true if the given descriptor or instance
        /// represents the given type.
        /// 
        /// May be applied to this, if element is omitted.
        abstract hasType: element: obj option * ``type``: string -> obj option
        /// Returns the descriptor of an elements named property
        abstract getPropertyDescriptor: element: obj option * property: obj option -> obj option
        /// Returns a mapped type's descriptor
        abstract getTypeDescriptor: ``type``: string -> obj option

    type [<AllowNullLiteral>] BPMNModdle =
        inherit Moddle
        /// <summary>Instantiates a BPMN model tree from a given xml string.</summary>
        /// <param name="xmlStr">XML string</param>
        /// <param name="done">done callback</param>
        abstract fromXML: xmlStr: string * ``done``: ImportFn -> unit
        /// <summary>Instantiates a BPMN model tree from a given xml string.</summary>
        /// <param name="xmlStr">XML string</param>
        /// <param name="options">Options to pass to the underlying reader</param>
        /// <param name="done">done callback</param>
        abstract fromXML: xmlStr: string * options: Option * ``done``: ImportFn -> unit
        /// <summary>Instantiates a BPMN model tree from a given xml string.</summary>
        /// <param name="xmlStr">XML string</param>
        /// <param name="typeName">Name of the root element</param>
        /// <param name="options">Options to pass to the underlying reader</param>
        /// <param name="done">done callback</param>
        abstract fromXML: xmlStr: string * typeName: string * options: Option * ``done``: ImportFn -> unit

    type [<AllowNullLiteral>] TypeLiteral_01 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
